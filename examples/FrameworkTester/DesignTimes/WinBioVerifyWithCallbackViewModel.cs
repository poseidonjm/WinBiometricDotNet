﻿using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioVerifyWithCallbackViewModel : WinBioViewModel, IWinBioVerifyWithCallbackViewModel, IWinBioAsyncSessionViewModel
    {

        public RelayCommand CancelCommand
        {
            get;
        }

        public bool EnableWait
        {
            get;
            set;
        }

        public bool IsMatch
        {
            get;
        }

        public RejectDetail RejectDetail
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        public FingerPosition SelectedFingerPosition
        {
            get;
            set;
        }

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}