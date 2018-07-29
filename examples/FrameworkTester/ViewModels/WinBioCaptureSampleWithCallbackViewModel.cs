﻿using System;
using System.Windows;
using System.Windows.Media.Imaging;
using FrameworkTester.Helpers;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioCaptureSampleWithCallbackViewModel : ViewModelBase, IWinBioCaptureSampleWithCallbackViewModel
    {

        #region Fields

        private readonly IWinBiometricService _Service;

        #endregion

        #region Constructors

        public WinBioCaptureSampleWithCallbackViewModel()
        {
            this._Service = SimpleIoc.Default.GetInstance<IWinBiometricService>();
            WinBiometric.SampleCaptured += this.WinBiometricOnSampleCaptured;
        }

        #endregion

        #region Properties

        private BitmapSource _CaptureImage;

        public BitmapSource CaptureImage
        {
            get
            {
                return this._CaptureImage;
            }
            private set
            {
                this._CaptureImage = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageWidth;

        public int CaptureImageWidth
        {
            get
            {
                return this._CaptureImageWidth;
            }
            private set
            {
                this._CaptureImageWidth = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageHeight;

        public int CaptureImageHeight
        {
            get
            {
                return this._CaptureImageHeight;
            }
            private set
            {
                this._CaptureImageHeight = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageHorizontalResolution;

        public int CaptureImageHorizontalResolution
        {
            get
            {
                return this._CaptureImageHorizontalResolution;
            }
            private set
            {
                this._CaptureImageHorizontalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageVerticalResolution;

        public int CaptureImageVerticalResolution
        {
            get
            {
                return this._CaptureImageVerticalResolution;
            }
            private set
            {
                this._CaptureImageVerticalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageScanHorizontalResolution;

        public int CaptureImageScanHorizontalResolution
        {
            get
            {
                return this._CaptureImageScanHorizontalResolution;
            }
            private set
            {
                this._CaptureImageScanHorizontalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageScanVerticalResolution;

        public int CaptureImageScanVerticalResolution
        {
            get
            {
                return this._CaptureImageScanVerticalResolution;
            }
            private set
            {
                this._CaptureImageScanVerticalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private RelayCommand _ExecuteCommand;

        public RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.Result = "WAIT";
                        this._Service.CaptureSampleWithCallback();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        private bool _Loop;

        public bool Loop
        {
            get
            {
                return this._Loop;
            }
            set
            {
                this._Loop = value;
                this.RaisePropertyChanged();
            }
        }

        public string Name => "WinBioCaptureSampleWithCallback";

        private string _Result;

        public string Result
        {
            get
            {
                return this._Result;
            }
            private set
            {
                this._Result = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _RejectDetail;

        public uint RejectDetail
        {
            get
            {
                return this._RejectDetail;
            }
            private set
            {
                this._RejectDetail = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _SampleSize;

        public uint SampleSize
        {
            get
            {
                return this._SampleSize;
            }
            private set
            {
                this._SampleSize = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _UnitId;

        public uint UnitId
        {
            get
            {
                return this._UnitId;
            }
            private set
            {
                this._UnitId = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricOnSampleCaptured(object sender, CaptureSampleEventArgs e)
        {
            switch (e.Result.OperationStatus)
            {
                case OperationStatus.OK:
                    this.Result = "OK";
                    break;
                case OperationStatus.BadCapture:
                    this.Result = "BadCapture";
                    break;
                case OperationStatus.Canceled:
                    this.Result = "Canceled";
                    break;
                case OperationStatus.Unknown:
                    this.Result = "Unknown";
                    break;
            }

            this.RejectDetail = e.Result.RejectDetail;
            this.SampleSize = e.Result.SampleSize;
            this.UnitId = e.Result.UnitId;

            var captureSample = e.Result.Sample;
            if (captureSample != null)
            {
                var image = BitmapSourceHelper.ToBitmapSource(captureSample.Image,
                    captureSample.Width,
                    captureSample.Height,
                    captureSample.HorizontalImageResolution,
                    captureSample.VerticalImageResolution);
                if (image.CanFreeze)
                    image.Freeze();
                this.CaptureImage = image;

                this.CaptureImageWidth = captureSample.Width;
                this.CaptureImageHeight = captureSample.Height;
                this.CaptureImageHorizontalResolution = captureSample.HorizontalImageResolution;
                this.CaptureImageVerticalResolution = captureSample.VerticalImageResolution;
                this.CaptureImageScanHorizontalResolution = captureSample.HorizontalScanResolution;
                this.CaptureImageScanVerticalResolution = captureSample.VerticalScanResolution;
            }
            else
            {
                this.CaptureImageWidth = -1;
                this.CaptureImageHeight = -1;
                this.CaptureImageHorizontalResolution = -1;
                this.CaptureImageVerticalResolution = -1;
                this.CaptureImageScanHorizontalResolution = -1;
                this.CaptureImageScanVerticalResolution = -1;
            }
        }

        #endregion

        #endregion

    }

}