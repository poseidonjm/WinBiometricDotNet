﻿using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioIdentifyViewModel : WinBioSessionViewModel, IWinBioIdentifyViewModel
    {

        #region Constructors

        public WinBioIdentifyViewModel()
        {
            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
        }

        #endregion

        #region Properties

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    this.Type = IdentityType.Null;
                    this.TemplateGuid = Guid.Empty;
                    this.Sid = "";
                    this.UnitId = 0;
                    this.FingerPosition = FingerPosition.Unknown;
                    this.RejectDetail = 0;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        var result = this.BiometricService.Identify(session);

                        this.Result = "OK";

                        this.Type = result.Identity.Type;
                        this.TemplateGuid = result.Identity.TemplateGuid;
                        this.Sid = result.Identity.Sid?.Value;
                        this.UnitId = result.UnitId;
                        this.FingerPosition = result.FingerPosition;
                        this.RejectDetail = result.RejectDetail;

                        this.IdentityRepository.Add(result.Identity);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioIdentify";

        private FingerPosition _FingerPosition;

        public FingerPosition FingerPosition
        {
            get => this._FingerPosition;
            private set
            {
                this._FingerPosition = value;
                this.RaisePropertyChanged();
            }
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        private RejectDetail _RejectDetail;

        public RejectDetail RejectDetail
        {
            get => this._RejectDetail;
            private set
            {
                this._RejectDetail = value;
                this.RaisePropertyChanged();
            }
        }

        private string _Sid;

        public string Sid
        {
            get => this._Sid;
            private set
            {
                this._Sid = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _UnitId;

        public uint UnitId
        {
            get => this._UnitId;
            private set
            {
                this._UnitId = value;
                this.RaisePropertyChanged();
            }
        }

        private Guid _TemplateGuid;

        public Guid TemplateGuid
        {
            get
            {
                return this._TemplateGuid;
            }
            private set
            {
                this._TemplateGuid = value;
                this.RaisePropertyChanged();
            }
        }

        private IdentityType _Type;

        public IdentityType Type
        {
            get
            {
                return this._Type;
            }
            private set
            {
                this._Type = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}