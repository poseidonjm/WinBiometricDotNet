﻿using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;
using WinBiometricDotNet.Runtime.InteropServices;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioIdentifyWithCallbackViewModel : WinBioWithCallbackViewModel, IWinBioIdentifyWithCallbackViewModel
    {

        #region Constructors

        public WinBioIdentifyWithCallbackViewModel()
        {
            WinBiometric.Identified -= this.WinBiometricIdentified;
            WinBiometric.Identified += this.WinBiometricIdentified;

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();

            this.WaitCallback = false;
        }

        #endregion

        #region Properties

        private RelayCommand _CancelCommand;

        public override RelayCommand CancelCommand
        {
            get
            {
                return this._CancelCommand ?? (this._CancelCommand = new RelayCommand(() =>
                {
                    try
                    {
                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.Cancel(session);

                        this.WaitCallback = false;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "WinBioCancel", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.WaitCallback = true;
                    }
                }, () => this.WaitCallback));
            }
        }

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
                    var name = this.Name;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.IdentifyWithCallback(session);

                        this.WaitCallback = true;

                        if (this.EnableWait)
                        {
                            name = "WinBioWait";
                            this.BiometricService.Wait(session);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";

                        this.WaitCallback = false;
                    }
                }, () => !this.WaitCallback && this.HandleRepository?.SelectedHandle != null));
            }
        }

        private bool _EnableWait;

        public override bool EnableWait
        {
            get => this._EnableWait;
            set
            {
                this._EnableWait = value;
                this.RaisePropertyChanged();
            }
        }

        public override string Name => "WinBioIdentifyWithCallback";

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
            get => this._TemplateGuid;
            private set
            {
                this._TemplateGuid = value;
                this.RaisePropertyChanged();
            }
        }

        private IdentityType _Type;

        public IdentityType Type
        {
            get => this._Type;
            private set
            {
                this._Type = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricIdentified(object sender, IdentifiedEventArgs e)
        {
            this.DispatcherService.SafeAction(() =>
            {
                this.WaitCallback = false;
            });

            this.Result = Marshal.GetWinBiometricExceptionFromHR(e.Result.OperationStatus).Message;

            var result = e.Result;
            this.Type = result.Identity.Type;
            this.TemplateGuid = result.Identity.TemplateGuid;
            this.Sid = result.Identity.Sid?.Value;
            this.UnitId = result.UnitId;
            this.FingerPosition = result.FingerPosition;
            this.RejectDetail = result.RejectDetail;

            this.DispatcherService.SafeAction(() =>
            {
                this.IdentityRepository.Add(result.Identity);
            });
        }

        #endregion

        #endregion

    }

}