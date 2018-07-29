﻿using System;
using System.Runtime.InteropServices;

namespace WinBiometricDotNet.Interop
{

    using BOOL = Int32;
    using BOOLEAN = Boolean;
    using BYTE = Byte;
    using DWORD = UInt32;
    using HRESULT = Int32;
    using HWND = IntPtr;
    using LONGLONG = Int64;
    using PUCHAR = IntPtr;
    using PVOID = IntPtr;
    using SIZE_T = IntPtr;
    using UCHAR = Byte;
    using UINT = UInt32;
    using ULONG = UInt32;
    using ULONG64 = UInt64;
    using ULONGLONG = UInt64;
    using USHORT = UInt16;
    using WORD = UInt16;

    using WINBIO_BIOMETRIC_SENSOR_SUBTYPE = UInt32;
    using WINBIO_BIOMETRIC_SUBTYPE = Byte;
    using WINBIO_BIOMETRIC_TYPE = UInt32;
    using WINBIO_BIR_DATA_FLAGS = Byte;
    using WINBIO_BIR_PURPOSE = Byte;
    using WINBIO_BIR_QUALITY = SByte;
    using WINBIO_BIR_VERSION = Byte;
    using WINBIO_CAPABILITIES = UInt32;
    using WINBIO_COMPONENT = UInt32;
    using WINBIO_EVENT_TYPE = UInt32;
    using WINBIO_FRAMEWORK_CHANGE_TYPE = UInt32;
    using WINBIO_FRAMEWORK_HANDLE = IntPtr;
    using WINBIO_IDENTITY_TYPE = UInt32;
    using WINBIO_INDICATOR_STATUS = UInt32;
    using WINBIO_OPERATION_TYPE = UInt32;
    using WINBIO_POOL_TYPE = UInt32;
    using WINBIO_PROPERTY_ID = UInt32;
    using WINBIO_PROPERTY_TYPE = UInt32;
    using WINBIO_REJECT_DETAIL = UInt32;
    using WINBIO_SENSOR_MODE = UInt32;
    using WINBIO_SENSOR_STATUS = UInt32;
    using WINBIO_SESSION_FLAGS = UInt32;
    using WINBIO_SESSION_HANDLE = IntPtr;
    using WINBIO_SETTING_SOURCE_TYPE = UInt32;
    using WINBIO_UNIT_ID = UInt32;
    using WINBIO_UUID = Guid;

    internal static class SafeNativeMethods
    {

        private const string DllName = "Winbio.dll";

        #region Constants

        public const int E_ACCESSDENIED = unchecked((int)0x80070005);

        public const int E_OUTOFMEMORY = unchecked((int)0x8007000E);

        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;

        public const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;

        public const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        public const uint FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;

        public const uint FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;

        public const uint FORMAT_MESSAGE_FROM_STRING = 0x00000400;

        #region BIO_UNIT Constants

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public const USHORT BIO_UNIT_RAW = 0x0001;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public const USHORT BIO_UNIT_MAINTENANCE = 0x0002;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public const USHORT BIO_UNIT_OPEN_SESSION = 0x0004;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public const USHORT BIO_UNIT_EXTENDED_ACCESS = 0x0008;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public const USHORT BIO_UNIT_ENROLL = 0x0010;

        public const USHORT BIO_UNIT_DELETE_TEMPLATE = 0x0020;

        public const USHORT BIO_UNIT_CONTROL_UNIT = 0x0040;

        #endregion

        #region Client Error Codes

        /// <summary>
        /// The specified biometric factor is not supported.
        /// </summary>
        public const int WINBIO_E_UNSUPPORTED_FACTOR = unchecked((int)0x80098001);

        /// <summary>
        /// The unit ID number does not correspond to a valid biometric device.
        /// </summary>
        public const int WINBIO_E_INVALID_UNIT = unchecked((int)0x80098002);

        /// <summary>
        /// The biometric sample does not match any known identity.
        /// </summary>
        public const int WINBIO_E_UNKNOWN_ID = unchecked((int)0x80098003);

        /// <summary>
        /// The biometric operation was canceled before it could complete.
        /// </summary>
        public const int WINBIO_E_CANCELED = unchecked((int)0x80098004);

        /// <summary>
        /// The biometric sample does not match the specified identity or sub-factor.
        /// </summary>
        public const int WINBIO_E_NO_MATCH = unchecked((int)0x80098005);

        /// <summary>
        /// A biometric sample could not be captured because the capture operation was aborted.
        /// </summary>
        public const int WINBIO_E_CAPTURE_ABORTED = unchecked((int)0x80098006);

        /// <summary>
        /// An enrollment transaction could not be started because another enrollment is already in progress.
        /// </summary>
        public const int WINBIO_E_ENROLLMENT_IN_PROGRESS = unchecked((int)0x80098007);

        /// <summary>
        /// The captured sample cannot be used for further biometric operations.
        /// </summary>
        public const int WINBIO_E_BAD_CAPTURE = unchecked((int)0x80098008);

        /// <summary>
        /// The biometric unit does not support the specified unit control code.
        /// </summary>
        public const int WINBIO_E_INVALID_CONTROL_CODE = unchecked((int)0x80098009);

        /// <summary>
        /// A pending data collection operation is already in progress.
        /// </summary>
        public const int WINBIO_E_DATA_COLLECTION_IN_PROGRESS = unchecked((int)0x8009800B);

        /// <summary>
        /// The biometric sensor driver does not support the requested data format.
        /// </summary>
        public const int WINBIO_E_UNSUPPORTED_DATA_FORMAT = unchecked((int)0x8009800C);

        /// <summary>
        /// The biometric sensor driver does not support the requested data type.
        /// </summary>
        public const int WINBIO_E_UNSUPPORTED_DATA_TYPE = unchecked((int)0x8009800D);

        /// <summary>
        /// The biometric sensor driver does not support the requested data purpose.
        /// </summary>
        public const int WINBIO_E_UNSUPPORTED_PURPOSE = unchecked((int)0x8009800E);

        /// <summary>
        /// The biometric unit is not in the proper state to perform the specified operation.
        /// </summary>
        public const int WINBIO_E_INVALID_DEVICE_STATE = unchecked((int)0x8009800F);

        /// <summary>
        /// The operation could not be performed because the sensor device was busy.
        /// </summary>
        public const int WINBIO_E_DEVICE_BUSY = unchecked((int)0x80098010);

        /// <summary>
        /// The storage adapter was not able to create a new database.
        /// </summary>
        public const int WINBIO_E_DATABASE_CANT_CREATE = unchecked((int)0x80098011);

        /// <summary>
        /// The storage adapter was not able to open an existing database.
        /// </summary>
        public const int WINBIO_E_DATABASE_CANT_OPEN = unchecked((int)0x80098012);

        /// <summary>
        /// The storage adapter was not able to close a database.
        /// </summary>
        public const int WINBIO_E_DATABASE_CANT_CLOSE = unchecked((int)0x80098013);

        /// <summary>
        /// The storage adapter was not able to erase a database.
        /// </summary>
        public const int WINBIO_E_DATABASE_CANT_ERASE = unchecked((int)0x80098014);

        /// <summary>
        /// The storage adapter was not able to find a database.
        /// </summary>
        public const int WINBIO_E_DATABASE_CANT_FIND = unchecked((int)0x80098015);

        /// <summary>
        /// The storage adapter was not able to create a database because the specified database already exists.
        /// </summary>
        public const int WINBIO_E_DATABASE_ALREADY_EXISTS = unchecked((int)0x80098016);

        /// <summary>
        /// The storage adapter was not able to add a record to the database because the database is full.
        /// </summary>
        public const int WINBIO_E_DATABASE_FULL = unchecked((int)0x80098018);

        /// <summary>
        /// The database is locked and its contents are inaccessible.
        /// </summary>
        public const int WINBIO_E_DATABASE_LOCKED = unchecked((int)0x80098019);

        /// <summary>
        /// The contents of the database have become corrupted and are inaccessible.
        /// </summary>
        public const int WINBIO_E_DATABASE_CORRUPTED = unchecked((int)0x8009801A);

        /// <summary>
        /// No records were deleted because the specified identity and sub-factor are not present in the database.
        /// </summary>
        public const int WINBIO_E_DATABASE_NO_SUCH_RECORD = unchecked((int)0x8009801B);

        /// <summary>
        /// The specified identity and sub-factor are already enrolled in the database.
        /// </summary>
        public const int WINBIO_E_DUPLICATE_ENROLLMENT = unchecked((int)0x8009801C);

        /// <summary>
        /// An error occurred while trying to read from the database.
        /// </summary>
        public const int WINBIO_E_DATABASE_READ_ERROR = unchecked((int)0x8009801D);

        /// <summary>
        /// An error occurred while trying to write to the database.
        /// </summary>
        public const int WINBIO_E_DATABASE_WRITE_ERROR = unchecked((int)0x8009801E);

        /// <summary>
        /// No records in the database matched the query.
        /// </summary>
        public const int WINBIO_E_DATABASE_NO_RESULTS = unchecked((int)0x8009801F);

        /// <summary>
        /// All records from the most recent database query have been retrieved.
        /// </summary>
        public const int WINBIO_E_DATABASE_NO_MORE_RECORDS = unchecked((int)0x80098020);

        /// <summary>
        /// A database operation unexpectedly encountered the end of the file.
        /// </summary>
        public const int WINBIO_E_DATABASE_EOF = unchecked((int)0x80098021);

        /// <summary>
        /// A database operation failed due to a malformed index vector.
        /// </summary>
        public const int WINBIO_E_DATABASE_BAD_INDEX_VECTOR = unchecked((int)0x80098022);

        /// <summary>
        /// The biometric unit does not belong to the specified service provider.
        /// </summary>
        public const int WINBIO_E_INCORRECT_BSP = unchecked((int)0x80098024);

        /// <summary>
        /// The biometric unit does not belong to the specified sensor pool.
        /// </summary>
        public const int WINBIO_E_INCORRECT_SENSOR_POOL = unchecked((int)0x80098025);

        /// <summary>
        /// The sensor adapter capture buffer is empty.
        /// </summary>
        public const int WINBIO_E_NO_CAPTURE_DATA = unchecked((int)0x80098026);

        /// <summary>
        /// The sensor adapter does not support the sensor mode specified in the configuration.
        /// </summary>
        public const int WINBIO_E_INVALID_SENSOR_MODE = unchecked((int)0x80098027);

        /// <summary>
        /// The requested operation cannot be performed due to a locking conflict.
        /// </summary>
        public const int WINBIO_E_LOCK_VIOLATION = unchecked((int)0x8009802A);

        /// <summary>
        /// The data in a biometric template matches that of another template already in the database.
        /// </summary>
        public const int WINBIO_E_DUPLICATE_TEMPLATE = unchecked((int)0x8009802B);

        /// <summary>
        /// The requested operation is not valid for the current state of the session or the biometric unit.
        /// </summary>
        public const int WINBIO_E_INVALID_OPERATION = unchecked((int)0x8009802C);

        /// <summary>
        /// The session cannot begin a new operation because another operation is already in progress.
        /// </summary>
        public const int WINBIO_E_SESSION_BUSY = unchecked((int)0x8009802D);

        /// <summary>
        /// System policy settings have disabled the biometric credential provider.
        /// </summary>
        public const int WINBIO_E_CRED_PROV_DISABLED = unchecked((int)0x80098030);

        /// <summary>
        /// The requested credential was not found.
        /// </summary>
        public const int WINBIO_E_CRED_PROV_NO_CREDENTIAL = unchecked((int)0x80098031);

        /// <summary>
        /// System policy settings have disabled the biometric service.
        /// </summary>
        public const int WINBIO_E_DISABLED = unchecked((int)0x80098032);

        /// <summary>
        /// The biometric unit could not be configured.
        /// </summary>
        public const int WINBIO_E_CONFIGURATION_FAILURE = unchecked((int)0x80098033);

        /// <summary>
        /// A private pool cannot be created because one or more biometric units are not available.
        /// </summary>
        public const int WINBIO_E_SENSOR_UNAVAILABLE = unchecked((int)0x80098034);

        /// <summary>
        /// A secure attention sequence (CTRL-ALT-DELETE) is required for logon.
        /// </summary>
        public const int WINBIO_E_SAS_ENABLED = unchecked((int)0x80098035);

        /// <summary>
        /// A biometric sensor has failed.
        /// </summary>
        public const int WINBIO_E_DEVICE_FAILURE = unchecked((int)0x80098036);

        /// <summary>
        /// >Fast user switching is disabled.
        /// </summary>
        public const int WINBIO_E_FAST_USER_SWITCH_DISABLED = unchecked((int)0x80098037);

        /// <summary>
        /// The System sensor pool cannot be opened from Terminal Server client sessions.
        /// </summary>
        public const int WINBIO_E_NOT_ACTIVE_CONSOLE = unchecked((int)0x80098038);

        /// <summary>
        /// There is already an active event monitor associated with the specified session.
        /// </summary>
        public const int WINBIO_E_EVENT_MONITOR_ACTIVE = unchecked((int)0x80098039);

        /// <summary>
        /// The value specified is not a valid property type.
        /// </summary>
        public const int WINBIO_E_INVALID_PROPERTY_TYPE = unchecked((int)0x8009803A);

        /// <summary>
        /// The value specified is not a valid property ID.
        /// </summary>
        public const int WINBIO_E_INVALID_PROPERTY_ID = unchecked((int)0x8009803B);

        /// <summary>
        /// The biometric unit does not support the specified property.
        /// </summary>
        public const int WINBIO_E_UNSUPPORTED_PROPERTY = unchecked((int)0x8009803C);

        /// <summary>
        /// The adapter did not pass its integrity check.
        /// </summary>
        public const int WINBIO_E_ADAPTER_INTEGRITY_FAILURE = unchecked((int)0x8009803D);

        /// <summary>
        /// Another sample is needed for the current enrollment template.
        /// </summary>
        public const int WINBIO_I_MORE_DATA = unchecked(0x00090001);

        #endregion

        #region General Constants

        /// <summary>
        /// The maximum length of a security identifier (SID) value. Currently this is 68.
        /// </summary>
        public const ULONG SECURITY_MAX_SID_SIZE = 68;

        /// <summary>
        /// The maximum length of a WINBIO_STRING value. Currently this is 256.
        /// </summary>
        public const int WINBIO_MAX_STRING_LEN = 256;

        /// <summary>
        /// The maximum number of bytes in a single biometric data capture.
        /// </summary>
        public const int WINBIO_MAX_SAMPLE_BUFFER_SIZE = 0x7FFFFFFF;

        #endregion

        #region WINBIO_ANSI_381_FORMAT Constants

        /// <summary>
        /// InterNational Committee for Information Technology Standards (INCITS) technical committee M1 (biometrics).
        /// </summary>
        public const USHORT WINBIO_ANSI_381_FORMAT_OWNER = 0x001B;   // INCITS Technical Committee M1

        /// <summary>
        /// ANSI INCITS 381 finger image based data interchange format.
        /// </summary>
        public const USHORT WINBIO_ANSI_381_FORMAT_TYPE = 0x0401; // ANSI-381

        #endregion

        #region WINBIO_ANSI_381_IMG Constants

        public const UCHAR WINBIO_ANSI_381_IMG_UNCOMPRESSED = 0;

        public const UCHAR WINBIO_ANSI_381_IMG_BIT_PACKED = 1;

        public const UCHAR WINBIO_ANSI_381_IMG_COMPRESSED_WSQ = 2;

        public const UCHAR WINBIO_ANSI_381_IMG_COMPRESSED_JPEG = 3;

        public const UCHAR WINBIO_ANSI_381_IMG_COMPRESSED_JPEG2000 = 4;

        public const UCHAR WINBIO_ANSI_381_IMG_COMPRESSED_PNG = 5;

        #endregion

        #region WINBIO_ANSI_381_IMG_ACQ Constants

        public const USHORT WINBIO_ANSI_381_IMG_ACQ_LEVEL_10 = 10;

        public const USHORT WINBIO_ANSI_381_IMG_ACQ_LEVEL_20 = 20;

        public const USHORT WINBIO_ANSI_381_IMG_ACQ_LEVEL_30 = 30;

        public const USHORT WINBIO_ANSI_381_IMG_ACQ_LEVEL_31 = 31;

        public const USHORT WINBIO_ANSI_381_IMG_ACQ_LEVEL_40 = 40;

        public const USHORT WINBIO_ANSI_381_IMG_ACQ_LEVEL_41 = 41;

        #endregion

        #region WINBIO_ANSI_381_IMP_TYPE Constants

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_LIVE_SCAN_PLAIN = 0;

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_LIVE_SCAN_ROLLED = 1;

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_NONLIVE_SCAN_PLAIN = 2;

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_NONLIVE_SCAN_ROLLED = 3;

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_LATENT = 7;

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_SWIPE = 8;

        public const UCHAR WINBIO_ANSI_381_IMP_TYPE_LIVE_SCAN_CONTACTLESS = 9;

        #endregion

        #region WINBIO_ANSI_381_PIXELS Constants

        public const UCHAR WINBIO_ANSI_381_PIXELS_PER_INCH = 0x01;

        public const UCHAR WINBIO_ANSI_381_PIXELS_PER_CM = 0x02;

        #endregion

        #region WINBIO_ANSI_381_POS Fingerprint Constants

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_UNKNOWN = 0;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_THUMB = 1;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_INDEX_FINGER = 2;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER = 3;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_RING_FINGER = 4;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_LITTLE_FINGER = 5;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_THUMB = 6;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_INDEX_FINGER = 7;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER = 8;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_RING_FINGER = 9;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_LITTLE_FINGER = 10;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_FOUR_FINGERS = 13;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_FOUR_FINGERS = 14;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_TWO_THUMBS = 15;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_01 = 0xF5;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_02 = 0xF6;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_03 = 0xF7;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_04 = 0xF8;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_05 = 0xF9;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_06 = 0xFA;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_07 = 0xFB;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_08 = 0xFC;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_09 = 0xFD;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_FINGER_UNSPECIFIED_POS_10 = 0xFE;

        #endregion

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_SUBTYPE_NO_INFORMATION = 0x00;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_SUBTYPE_ANY = 0xFF;

        #region WINBIO_ANSI_381_POS Palm Constants

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_UNKNOWN_PALM = 20;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_FULL_PALM = 21;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_WRITERS_PALM = 22;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_FULL_PALM = 23;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_WRITERS_PALM = 24;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_LOWER_PALM = 25;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_UPPER_PALM = 26;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_LOWER_PALM = 27;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_UPPER_PALM = 28;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_OTHER = 29;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_OTHER = 30;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_INTERDIGITAL = 31;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_THENAR = 32;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_RH_HYPOTHENAR = 33;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_INTERDIGITAL = 34;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_THENAR = 35;

        public const WINBIO_BIOMETRIC_SUBTYPE WINBIO_ANSI_381_POS_LH_HYPOTHENAR = 36;

        #endregion

        #region WINBIO_BIOMETRIC_SENSOR_SUBTYPE Constants

        public const WINBIO_BIOMETRIC_SENSOR_SUBTYPE WINBIO_SENSOR_SUBTYPE_UNKNOWN = 0x00000000;

        /// <summary>
        /// The device requires the user to swipe their fingertip over the sensor.
        /// </summary>
        public const WINBIO_BIOMETRIC_SENSOR_SUBTYPE WINBIO_FP_SENSOR_SUBTYPE_SWIPE = 0x00000001;

        /// <summary>
        /// The device requires the user to place their entire fingerprint on a sensor pad.
        /// </summary>
        public const WINBIO_BIOMETRIC_SENSOR_SUBTYPE WINBIO_FP_SENSOR_SUBTYPE_TOUCH = 0x00000002;

        #endregion

        #region WINBIO_BIOMETRIC_TYPE Constants

        /// <summary>
        /// Bitmask that specifies the supported set of biometric factors.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_STANDARD_TYPE_MASK = 0x00FFFFFF;

        /// <summary>
        /// No biometric type is available.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_NO_TYPE_AVAILABLE = 0x00000000;

        /// <summary>
        /// Multiple types are specified.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_MULTIPLE = 0x00000001;

        /// <summary>
        /// The biometric sensor captures facial features.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_FACIAL_FEATURES = 0x00000002;

        /// <summary>
        /// The biometric sensor captures voice data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_VOICE = 0x00000004;

        /// <summary>
        /// The biometric sensor captures fingerprint data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_FINGERPRINT = 0x00000008;

        /// <summary>
        /// The biometric sensor captures iris data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_IRIS = 0x00000010;

        /// <summary>
        /// The biometric sensor captures retina data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_RETINA = 0x00000020;

        /// <summary>
        /// The biometric sensor captures hand data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_HAND_GEOMETRY = 0x00000040;

        /// <summary>
        /// The biometric sensor captures signatures.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_SIGNATURE_DYNAMICS = 0x00000080;

        /// <summary>
        /// The biometric sensor captures keystrokes.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_KEYSTROKE_DYNAMICS = 0x00000100;

        /// <summary>
        /// The biometric sensor captures lip data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_LIP_MOVEMENT = 0x00000200;

        /// <summary>
        /// The biometric sensor captures thermal face imaging.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_THERMAL_FACE_IMAGE = 0x00000400;

        /// <summary>
        /// The biometric sensor captures thermal hand imaging.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_THERMAL_HAND_IMAGE = 0x00000800;

        /// <summary>
        /// The biometric sensor captures walking gait data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_GAIT = 0x00001000;

        /// <summary>
        /// The biometric sensor captures scent data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_SCENT = 0x00002000;

        /// <summary>
        /// The biometric sensor captures DNA data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_DNA = 0x00004000;

        /// <summary>
        /// The biometric sensor captures ear information.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_EAR_SHAPE = 0x00008000;

        /// <summary>
        /// The biometric sensor captures finger shape information.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_FINGER_GEOMETRY = 0x00010000;

        /// <summary>
        /// The biometric sensor captures palm prints.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_PALM_PRINT = 0x00020000;

        /// <summary>
        /// The biometric sensor captures blood vein pattern data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_VEIN_PATTERN = 0x00040000;

        /// <summary>
        /// The biometric sensor captures foot prints.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_FOOT_PRINT = 0x00080000;

        /// <summary>
        /// The supported biometric data is not defined by the current constants.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_OTHER = 0x40000000;

        /// <summary>
        /// The biometric sensor captures password data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_PASSWORD = 0x80000000;

        /// <summary>
        /// The biometric sensor captures any type of data.
        /// </summary>
        public const WINBIO_BIOMETRIC_TYPE WINBIO_TYPE_ANY = (WINBIO_STANDARD_TYPE_MASK | WINBIO_TYPE_OTHER | WINBIO_TYPE_PASSWORD);

        #endregion

        #region WINBIO_BIR_DATA_FLAGS Constants

        /// <summary>
        /// The data is encrypted.
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_PRIVACY = 0x02;

        /// <summary>
        /// The data is digitally signed or is protected by a message authentication code (MAC).
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_INTEGRITY = 0x01;

        /// <summary>
        /// If this flag and the <see cref="WINBIO_DATA_FLAG_INTEGRITY"/> flag are set, the data is signed. If this flag is not set but the <see cref="WINBIO_DATA_FLAG_INTEGRITY"/> flag is set, a MAC is computed on the data.
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_SIGNED = 0x04;

        /// <summary>
        /// The data is in the format with which it was captured.
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_RAW = 0x20;

        /// <summary>
        /// The data is not raw but has not been completely processed.
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_INTERMEDIATE = 0x40;

        /// <summary>
        /// The data has been processed.
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_PROCESSED = 0x80;

        /// <summary>
        /// The flag mask. This value is always one (1).
        /// </summary>
        public const WINBIO_BIR_DATA_FLAGS WINBIO_DATA_FLAG_OPTION_MASK_PRESENT = 0x08;

        #endregion

        #region WINBIO_BIR_FIELD Constants

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, the Common Biometric Exchange Formats Framework (CBEFF) Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_SUBHEAD_COUNT = 0x0001;

        /// <summary>
        /// The ProductId member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_PRODUCT_ID = 0x0002;

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_PATRON_ID = 0x0004;

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_INDEX = 0x0008;

        /// <summary>
        /// The CreationDate member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_CREATION_DATE = 0x0010;

        /// <summary>
        /// The ValidityPeriod member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_VALIDITY_PERIOD = 0x0020;

        /// <summary>
        /// The Type member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_BIOMETRIC_TYPE = 0x0040;

        /// <summary>
        /// The Subtype member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_BIOMETRIC_SUBTYPE = 0x0080;

        /// <summary>
        /// The HeaderVersion member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_CBEFF_HEADER_VERSION = 0x0100;

        /// <summary>
        /// The PatronHeaderVersion member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_PATRON_HEADER_VERSION = 0x0200;

        /// <summary>
        /// The Purpose member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_BIOMETRIC_PURPOSE = 0x0400;

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_BIOMETRIC_CONDITION = 0x0800;

        /// <summary>
        /// The DataQuality member is valid.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_QUALITY = 0x1000;

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_CREATOR = 0x2000;

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_CHALLENGE = 0x4000;

        /// <summary>
        /// Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.
        /// </summary>
        public const USHORT WINBIO_BIR_FIELD_PAYLOAD = 0x8000;

        #endregion

        #region WINBIO_BIR_PURPOSE Constants

        /// <summary>
        /// No purpose is specified.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_NO_PURPOSE_AVAILABLE = 0x00;

        /// <summary>
        /// Verify the identity of a user.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_PURPOSE_VERIFY = 0x01;

        /// <summary>
        /// Identify a user.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_PURPOSE_IDENTIFY = 0x02;

        /// <summary>
        /// Enroll a user.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_PURPOSE_ENROLL = 0x04;

        /// <summary>
        /// Capture a biometric sample and determine whether the sample corresponds to the specified user identity.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION = 0x08;

        /// <summary>
        /// Capture a biometric sample and determine whether it matches an existing biometric template.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION = 0x10;

        /// <summary>
        /// Extra information that can be used for logging or for display. This value is ignored on input by all functions. On output, it will only be available if supported by the biometric unit and you specify WINBIO_DATA_FLAG_RAW in the Flags parameter of the WinBioCaptureSample function.
        /// </summary>
        public const WINBIO_BIR_PURPOSE WINBIO_PURPOSE_AUDIT = 0x80;

        #endregion

        #region WINBIO_BIR_QUALITY Constants

        /// <summary>
        /// Quality measurements are supported by the BIR creator, but no value is set in the BIR.
        /// </summary>
        public const WINBIO_BIR_QUALITY WINBIO_DATA_QUALITY_NOT_SET = (-1);

        /// <summary>
        /// Quality measurements are not supported by the BIR creator.
        /// </summary>
        public const WINBIO_BIR_QUALITY WINBIO_DATA_QUALITY_NOT_SUPPORTED = (-2);

        #endregion

        #region WINBIO_BIR_VERSION Constants

        /// <summary>
        /// Specifies the header version.
        /// </summary>
        public const WINBIO_BIR_VERSION WINBIO_CBEFF_HEADER_VERSION = 0x11;

        /// <summary>
        /// Specifies the patron header version.
        /// </summary>
        public const WINBIO_BIR_VERSION WINBIO_PATRON_HEADER_VERSION = 0x11;

        #endregion

        #region WINBIO_CAPABILITY Constants

        /// <summary>
        /// The device can collect biometric data.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_SENSOR = (0x00000001);

        /// <summary>
        /// The device can perform match operations.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_MATCHING = (0x00000002);

        /// <summary>
        /// The sensor contains an onboard database.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_DATABASE = (0x00000004);

        /// <summary>
        /// The device can process samples and turn them into biometric templates.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_PROCESSING = (0x00000008);

        /// <summary>
        /// The device supports encryption of samples and templates.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_ENCRYPTION = (0x00000010);

        /// <summary>
        /// The device can be used as a navigation device. Some devices and drivers can capture data in a format that can be translated by a user-mode application into navigation events, much like a mouse.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_NAVIGATION = (0x00000020);

        /// <summary>
        /// The device has an indicator that can be turned on or off.
        /// </summary>
        public const WINBIO_CAPABILITIES WINBIO_CAPABILITY_INDICATOR = (0x00000040);

        #endregion

        #region WINBIO_COMPONENT Constants

        /// <summary>
        /// Specifies a sensor adapter.
        /// </summary>
        public const WINBIO_COMPONENT WINBIO_COMPONENT_SENSOR = 1;

        /// <summary>
        /// Specifies an engine adapter.
        /// </summary>
        public const WINBIO_COMPONENT WINBIO_COMPONENT_ENGINE = 2;

        /// <summary>
        /// Specifies a storage adapter.
        /// </summary>
        public const WINBIO_COMPONENT WINBIO_COMPONENT_STORAGE = 3;

        #endregion

        #region WINBIO_DATABASE_TYPE Constants

        /// <summary>
        /// Represents a mask for all of the _TYPE_ bits.
        /// </summary>
        public const ULONG WINBIO_DATABASE_TYPE_MASK = 0x0000FFFF;

        /// <summary>
        /// The database is contained in a file.
        /// </summary>
        public const ULONG WINBIO_DATABASE_TYPE_FILE = 0x00000001;

        /// <summary>
        /// The database is managed by an external database management system (DBMS) component, such as Microsoft SQL Server.
        /// </summary>
        public const ULONG WINBIO_DATABASE_TYPE_DBMS = 0x00000002;

        /// <summary>
        /// The database resides on the biometric sensor.
        /// </summary>
        public const ULONG WINBIO_DATABASE_TYPE_ONCHIP = 0x00000003;

        /// <summary>
        /// The database resides on a smart card.
        /// </summary>
        public const ULONG WINBIO_DATABASE_TYPE_SMARTCARD = 0x00000004;

        /// <summary>
        /// Represents a mask for all of the _FLAG_ bits.
        /// </summary>
        public const ULONG WINBIO_DATABASE_FLAG_MASK = 0xFFFF0000;

        /// <summary>
        /// The storage medium containing the database can be physically removed from the computer.
        /// </summary>
        public const ULONG WINBIO_DATABASE_FLAG_REMOVABLE = 0x00010000;

        /// <summary>
        /// The database resides on a remote computer.
        /// </summary>
        public const ULONG WINBIO_DATABASE_FLAG_REMOTE = 0x00020000;

        #endregion

        #region WINBIO_DB Constants

        private static Guid _WINBIO_DB_DEFAULT = new Guid(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });

        /// <summary>
        /// Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration.
        /// </summary>
        public unsafe static Guid* WINBIO_DB_DEFAULT
        {
            get
            {
                fixed (Guid* p = &_WINBIO_DB_DEFAULT)
                {
                    return p;
                }
            }
        }

        private static Guid _WINBIO_DB_BOOTSTRAP = new Guid(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 });

        /// <summary>
        /// Can be used for scenarios prior to starting Windows. Typically, the database is part of the sensor chip or is part of the BIOS and can only be used for template enrollment and deletion.
        /// </summary>
        public unsafe static Guid* WINBIO_DB_BOOTSTRAP
        {
            get
            {
                fixed (Guid* p = &_WINBIO_DB_BOOTSTRAP)
                {
                    return p;
                }
            }
        }

        private static Guid _WINBIO_DB_ONCHIP = new Guid(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 });

        /// <summary>
        /// The database resides on the sensor chip.
        /// </summary>
        public unsafe static Guid* WINBIO_DB_ONCHIP
        {
            get
            {
                fixed (Guid* p = &_WINBIO_DB_ONCHIP)
                {
                    return p;
                }
            }
        }

        #endregion

        #region WINBIO_EVENT_TYPE Constants

        public const WINBIO_EVENT_TYPE WINBIO_EVENT_ERROR = 0xFFFFFFFF;

        /// <summary>
        /// The sensor detected a finger swipe that was not requested by the application or by the window that currently has focus. The Windows Biometric Framework calls into your callback function to indicate that a finger swipe has occurred but does not try to identify the fingerprint.
        /// </summary>
        public const WINBIO_EVENT_TYPE WINBIO_EVENT_FP_UNCLAIMED = 0x00000001;

        /// <summary>
        /// The sensor detected a finger swipe that was not requested by the application or by the window that currently has focus. The Windows Biometric Framework attempts to identify the fingerprint and passes the result of that process to your callback function.
        /// </summary>
        public const WINBIO_EVENT_TYPE WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY = 0x00000002;

        #endregion

        #region WINBIO_FLAG Constants

        /// <summary>
        /// Sensor configuration flag. The biometric units operate in the manner specified during installation.
        /// </summary>
        public const WINBIO_SESSION_FLAGS WINBIO_FLAG_DEFAULT = (0x00000000);

        /// <summary>
        /// Sensor configuration flag. The biometric units operate only as basic capture devices.
        /// </summary>
        public const WINBIO_SESSION_FLAGS WINBIO_FLAG_BASIC = ((((int)WINBIO_SENSOR_BASIC_MODE & 0xFFFF) << 16));

        /// <summary>
        /// Sensor configuration flag. The biometric units use internal processing and storage capabilities.
        /// </summary>
        public const WINBIO_SESSION_FLAGS WINBIO_FLAG_ADVANCED = ((((int)WINBIO_SENSOR_ADVANCED_MODE & 0xFFFF) << 16));

        /// <summary>
        /// Desired access flag. The client application captures raw biometric data using <see cref="WinBioCaptureSample"/>.
        /// </summary>
        public const WINBIO_SESSION_FLAGS WINBIO_FLAG_RAW = (BIO_UNIT_RAW);

        /// <summary>
        /// Desired access flag. The client performs vendor-defined control operations on a biometric unit by calling <see cref="WinBioControlUnitPrivileged"/>.
        /// </summary>
        public const WINBIO_SESSION_FLAGS WINBIO_FLAG_MAINTENANCE = (BIO_UNIT_MAINTENANCE);

        #endregion

        #region WINBIO_FRAMEWORK_CHANGE_TYPE Constants

        /// <summary>
        /// A biometric unit has been attached to or detached from the computer.
        /// </summary>
        public const WINBIO_FRAMEWORK_CHANGE_TYPE WINBIO_FRAMEWORK_CHANGE_UNIT = 0x00000001;

        #endregion

        #region WINBIO_IDENTITY_TYPE Constants

        /// <summary>
        /// The template has no associated ID.
        /// </summary>
        public const WINBIO_IDENTITY_TYPE WINBIO_ID_TYPE_NULL = 0;

        /// <summary>
        /// The structure matches all template identities.
        /// </summary>
        public const WINBIO_IDENTITY_TYPE WINBIO_ID_TYPE_WILDCARD = 1;

        /// <summary>
        /// A GUID identifies the template.
        /// </summary>
        public const WINBIO_IDENTITY_TYPE WINBIO_ID_TYPE_GUID = 2;

        /// <summary>
        /// An account SID identifies the template.
        /// </summary>
        public const WINBIO_IDENTITY_TYPE WINBIO_ID_TYPE_SID = 3;

        #endregion

        #region WINBIO_INDICATOR_STATUS Constants

        /// <summary>
        /// The sensor indicator light is on.
        /// </summary>
        public const WINBIO_INDICATOR_STATUS WINBIO_INDICATOR_ON = 1;

        /// <summary>
        /// The sensor indicator light is off.
        /// </summary>
        public const WINBIO_INDICATOR_STATUS WINBIO_INDICATOR_OFF = 2;

        #endregion

        #region WINBIO_NO_FORMAT Constants

        /// <summary>
        /// No IBIA (International Biometric Industry Association) assigned owner value is available.
        /// </summary>
        public const USHORT WINBIO_NO_FORMAT_OWNER_AVAILABLE = 0;

        /// <summary>
        /// No owner assigned format type is available.
        /// </summary>
        public const USHORT WINBIO_NO_FORMAT_TYPE_AVAILABLE = 0;

        #endregion

        #region WINBIO_OPERATION_TYPE Constants

        /// <summary>
        /// No operation has been identified.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_NONE = 0;

        /// <summary>
        /// A biometric session was opened. For more information see WinBioAsyncOpenSession.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_OPEN = 1;

        /// <summary>
        /// A biometric session was closed. For more information, see WinBioCloseSession.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_CLOSE = 2;

        /// <summary>
        /// A biometric sample was verified against a user identity. For more information, see WinBioVerify.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_VERIFY = 3;

        /// <summary>
        /// A biometric sample was captured and compared to an existing template. For more information, see WinBioIdentify.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_IDENTIFY = 4;

        /// <summary>
        /// The ID number of a biometric unit was retrieved. For more information, see WinBioLocateSensor.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_LOCATE_SENSOR = 5;

        /// <summary>
        /// A biometric enrollment sequence was initiated. For more information, see WinBioEnrollBegin.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENROLL_BEGIN = 6;

        /// <summary>
        /// A biometric sample was captured and added to the template. For more information, see WinBioEnrollCapture.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENROLL_CAPTURE = 7;

        /// <summary>
        /// A pending biometric template was finalized. For more information, see WinBioEnrollCommit.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENROLL_COMMIT = 8;

        /// <summary>
        /// A pending biometric template was discarded. For more information, see WinBioEnrollDiscard.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENROLL_DISCARD = 9;

        /// <summary>
        /// The sub-factors for a given template were enumerated. For more information, see WinBioEnumEnrollments.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENUM_ENROLLMENTS = 10;

        /// <summary>
        /// A biometric template was deleted from the store. For more information, see WinBioDeleteTemplate.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_DELETE_TEMPLATE = 11;

        /// <summary>
        /// A biometric sample was captured. For more information, see WinBioCaptureSample.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_CAPTURE_SAMPLE = 12;

        /// <summary>
        /// A biometric session, unit, or template property was retrieved. For more information, see WinBioGetProperty.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_GET_PROPERTY = 13;

        /// <summary>
        /// Not used.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_SET_PROPERTY = 14;

        /// <summary>
        /// Not used.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_GET_EVENT = 15;

        /// <summary>
        /// A biometric unit was locked for exclusive use by a session. For more information, see WinBioLockUnit.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_LOCK_UNIT = 16;

        /// <summary>
        /// The session lock on a biometric unit was released. For more information, see WinBioUnlockUnit.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_UNLOCK_UNIT = 17;

        /// <summary>
        /// Vendor defined operations were performed on a control unit. For more information, see WinBioControlUnit.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_CONTROL_UNIT = 18;

        /// <summary>
        /// Privileged vendor defined operations were performed on a control unit. For more information, see WinBioControlUnitPrivileged.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_CONTROL_UNIT_PRIVILEGED = 19;

        /// <summary>
        /// A handle to the biometric framework was opened.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_OPEN_FRAMEWORK = 20;

        /// <summary>
        /// A handle to the biometric framework was closed. For more information, see WinBioCloseFramework.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_CLOSE_FRAMEWORK = 21;

        /// <summary>
        /// The installed biometric service providers were enumerated. For more information, see WinBioEnumServiceProviders.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENUM_SERVICE_PROVIDERS = 22;

        /// <summary>
        /// The attached biometric units were enumerated. For more information, see WinBioEnumBiometricUnits.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENUM_BIOMETRIC_UNITS = 23;

        /// <summary>
        /// The registered databases were enumerated. For more information, see WinBioEnumDatabases.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_ENUM_DATABASES = 24;

        /// <summary>
        /// A biometric unit was created. For more information, see WinBioAsyncMonitorFrameworkChanges.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_UNIT_ARRIVAL = 25;

        /// <summary>
        /// A biometric unit was deleted. For more information, see WinBioAsyncMonitorFrameworkChanges.
        /// </summary>
        public const WINBIO_OPERATION_TYPE WINBIO_OPERATION_UNIT_REMOVAL = 26;

        #endregion

        #region WINBIO_POOL_TYPE Constants

        public const WINBIO_POOL_TYPE WINBIO_POOL_UNKNOWN = 0;

        /// <summary>
        /// The session connects to a shared collection of biometric units managed by the service provider.
        /// </summary>
        public const WINBIO_POOL_TYPE WINBIO_POOL_SYSTEM = 1;

        /// <summary>
        /// The session connects to a collection of biometric units that are managed by the caller.
        /// </summary>
        public const WINBIO_POOL_TYPE WINBIO_POOL_PRIVATE = 2;

        public const WINBIO_POOL_TYPE WINBIO_POOL_UNASSIGNED = 3;

        #endregion

        #region WINBIO_PROPERTY_ID

        /// <summary>
        /// A biometric session.
        /// </summary>
        public const WINBIO_PROPERTY_ID WINBIO_PROPERTY_SAMPLE_HINT = 1;

        #endregion

        #region WINBIO_PROPERTY_TYPE Constants

        /// <summary>
        /// A biometric session.
        /// </summary>
        public const WINBIO_PROPERTY_TYPE WINBIO_PROPERTY_TYPE_SESSION = 1;

        /// <summary>
        /// A biometric unit.
        /// </summary>
        public const WINBIO_PROPERTY_TYPE WINBIO_PROPERTY_TYPE_UNIT = 2;

        /// <summary>
        /// A biometric template.
        /// </summary>
        public const WINBIO_PROPERTY_TYPE WINBIO_PROPERTY_TYPE_TEMPLATE = 3;

        #endregion

        #region WINBIO_REJECT_DETAIL Constants

        /// <summary>
        /// The finger scan began too high on the finger.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_HIGH = 1;

        /// <summary>
        /// The finger scan began too low on the finger.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_LOW = 2;

        /// <summary>
        /// The finger was too far left during scanning.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_LEFT = 3;

        /// <summary>
        /// The finger was too far right during scanning.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_RIGHT = 4;

        /// <summary>
        /// The finger was swiped too quickly on the sensor.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_FAST = 5;

        /// <summary>
        /// The finger was swiped too slowly on the sensor.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_SLOW = 6;

        /// <summary>
        /// The scan quality was too poor.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_POOR_QUALITY = 7;

        /// <summary>
        /// The finger did not pass straight across the sensor.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_SKEWED = 8;

        /// <summary>
        /// Not enough of the finger was scanned.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_TOO_SHORT = 9;

        /// <summary>
        /// The fingerprint captures could not be combined.
        /// </summary>
        public const WINBIO_REJECT_DETAIL WINBIO_FP_MERGE_FAILURE = 10;

        #endregion

        #region WINBIO_SENSOR_MODE Constants

        /// <summary>
        /// The operating mode is not known.
        /// </summary>
        public const WINBIO_SENSOR_MODE WINBIO_SENSOR_UNKNOWN_MODE = 0;

        /// <summary>
        /// Operate the sensor in basic mode. The sensor acts only as a capture device. Any onboard processing or storage capabilities that exist are not used.
        /// </summary>
        public const WINBIO_SENSOR_MODE WINBIO_SENSOR_BASIC_MODE = 1;

        /// <summary>
        /// Operate the sensor in advanced mode. The sensor can capture samples and perform matching and storage functions.
        /// </summary>
        public const WINBIO_SENSOR_MODE WINBIO_SENSOR_ADVANCED_MODE = 2;

        /// <summary>
        /// Operate the sensor as a mouse pad. This is not currently supported.
        /// </summary>
        public const WINBIO_SENSOR_MODE WINBIO_SENSOR_NAVIGATION_MODE = 3;

        /// <summary>
        /// Operate the sensor in sleep mode.
        /// </summary>
        public const WINBIO_SENSOR_MODE WINBIO_SENSOR_SLEEP_MODE = 4;


        #endregion

        #region WINBIO_SETTING_SOURCE_TYPE Constans

        /// <summary>
        /// The setting is not valid.
        /// </summary>
        public const WINBIO_SETTING_SOURCE_TYPE WINBIO_SETTING_SOURCE_INVALID = 0;

        /// <summary>
        /// The setting originated from built-in policy.
        /// </summary>
        public const WINBIO_SETTING_SOURCE_TYPE WINBIO_SETTING_SOURCE_DEFAULT = 1;

        /// <summary>
        /// The setting was created by Group Policy.
        /// </summary>
        public const WINBIO_SETTING_SOURCE_TYPE WINBIO_SETTING_SOURCE_POLICY = 2;

        /// <summary>
        /// The setting originated in the local computer registry.
        /// </summary>
        public const WINBIO_SETTING_SOURCE_TYPE WINBIO_SETTING_SOURCE_LOCAL = 3;

        #endregion

        #endregion

        #region Callbacks

        /// <summary>
        /// Called by the Windows Biometric Framework to notify the client application that an asynchronous operation has completed. The callback is defined by the client application and called by the Windows Biometric Framework.
        /// </summary>
        /// <param name="AsyncResult">Pointer to a <see cref="WINBIO_ASYNC_RESULT"/> structure that contains information about the completed operation. The structure is created by the Windows Biometric Framework. You must call WinBioFree to release the structure.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public unsafe delegate void WINBIO_ASYNC_COMPLETION_CALLBACK([In] WINBIO_ASYNC_RESULT* AsyncResult);

        /// <summary>
        /// <para>Called by the Windows Biometric Framework to return results from the asynchronous <see cref="WinBioCaptureSampleWithCallback"/> function. The client application must implement this function.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use the <see cref="PWINBIO_CAPTURE_CALLBACK"/>/<see cref="WinBioCaptureSampleWithCallback"/> combination. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the <paramref name="CallbackRoutine"/> parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the <paramref name="NotificationMethod"/> parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioCaptureSample"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="CaptureCallbackContext">Pointer to a buffer defined by the application and passed to the <paramref name="CaptureCallbackContext"/> parameter of the <see cref="WinBioCaptureSampleWithCallback"/> function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.</param>
        /// <param name="OperationStatus">Error code returned by the capture operation.</param>
        /// <param name="UnitId">Biometric unit ID number.</param>
        /// <param name="Sample">Pointer to the sample data.</param>
        /// <param name="SampleSize">Size, in bytes, of the sample data pointed to by the Sample parameter.</param>
        /// <param name="RejectDetail">Additional information about the failure, if any, to perform the operation. For more information, see Remarks.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public unsafe delegate void WINBIO_CAPTURE_CALLBACK([In] PVOID CaptureCallbackContext,
                                                            [In] HRESULT OperationStatus,
                                                            [In] WINBIO_UNIT_ID UnitId,
                                                            [In] WINBIO_BIR* Sample,
                                                            [In] SIZE_T SampleSize,
                                                            [In] WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// <para>The <see cref="PWINBIO_ENROLL_CAPTURE_CALLBACK"/> function is called by the Windows Biometric Framework to return results from the asynchronous <see cref="WinBioEnrollCaptureWithCallback"/> function. The client application must implement this function.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use the <see cref="PWINBIO_ENROLL_CAPTURE_CALLBACK"/>/<see cref="WinBioEnrollCaptureWithCallback"/> combination. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioEnrollCapture"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="EnrollCallbackContext">Pointer to a buffer defined by the application and passed to the EnrollCallback parameter of the <see cref="WinBioEnrollCaptureWithCallback"/> function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.</param>
        /// <param name="OperationStatus">Error code returned by the capture operation.</param>
        /// <param name="RejectDetail">Additional information about the failure, if any, to perform the operation. For more information, see Remarks.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WINBIO_ENROLL_CAPTURE_CALLBACK([In] PVOID EnrollCallbackContext,
                                                            [In] HRESULT OperationStatus,
                                                            [In] WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// Called by the Windows Biometric Framework to return results from the asynchronous <see cref="WinBioRegisterEventMonitor"/> function. The client application must implement this function.
        /// </summary>
        /// <param name="EventCallbackContext">Pointer to a buffer defined by the application and passed to the EventCallbackContext parameter of the <see cref="WinBioRegisterEventMonitor"/> function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.</param>
        /// <param name="OperationStatus">Error code returned by the capture operation.</param>
        /// <param name="Event">Pointer to a <see cref="WINBIO_EVENT"/> value. For more information, see <see cref="WINBIO_EVENT"/> Constants.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public unsafe delegate void WINBIO_EVENT_CALLBACK([In] PVOID EventCallbackContext,
                                                          [In] HRESULT OperationStatus,
                                                          [In] WINBIO_EVENT* Event);

        /// <summary>
        /// <para>The <see cref="PWINBIO_IDENTIFY_CALLBACK"/> function is called by the Windows Biometric Framework to return results from the asynchronous <see cref="WinBioIdentifyWithCallback"/> function. The client application must implement this function.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use the <see cref="PWINBIO_IDENTIFY_CALLBACK"/>/<see cref="WinBioIdentifyWithCallback"/> combination. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioIdentify"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="IdentifyCallbackContext">Pointer to a buffer defined by the application and passed to the IdentifyCallbackContext parameter of the <see cref="WinBioIdentifyWithCallback"/> function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.</param>
        /// <param name="OperationStatus">Error code returned by the capture operation.</param>
        /// <param name="UnitId">Biometric unit ID number.</param>
        /// <param name="Identity">A <see cref="WINBIO_IDENTITY"/> structure that receives the GUID or SID of the user providing the biometric sample.</param>
        /// <param name="SubFactor">A <see cref="WINBIO_BIOMETRIC_SUBTYPE"/> value that receives the sub-factor associated with the biometric sample. See the Remarks section for more details.</param>
        /// <param name="RejectDetail">Additional information about the failure, if any, to perform the operation. For more information, see Remarks.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public unsafe delegate void WINBIO_IDENTIFY_CALLBACK([In] PVOID IdentifyCallbackContext,
                                                             [In] HRESULT OperationStatus,
                                                             [In] WINBIO_UNIT_ID UnitId,
                                                             [In] WINBIO_IDENTITY* Identity,
                                                             [In] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
                                                             [In] WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// <para>Called by the Windows Biometric Framework to return results from the asynchronous <see cref="WinBioLocateSensorWithCallback"/> function. The client application must implement this function.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use the <see cref="PWINBIO_LOCATE_SENSOR_CALLBACK"/>/<see cref="WinBioLocateSensorWithCallback"/> combination. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioLocateSensor"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="LocateCallbackContext">Pointer to a buffer defined by the application and passed to the LocateCallbackContext parameter of the WinBioLocateSensorWithCallback function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.</param>
        /// <param name="OperationStatus">Error code returned by the capture operation.</param>
        /// <param name="UnitId">Biometric unit ID number.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WINBIO_LOCATE_SENSOR_CALLBACK([In] PVOID LocateCallbackContext,
                                                           [In] HRESULT OperationStatus,
                                                           [In] WINBIO_UNIT_ID UnitId);

        /// <summary>
        /// <para>Called by the Windows Biometric Framework to return results from the asynchronous <see cref="WinBioVerifyWithCallback"/> function. The client application must implement this function.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use the <see cref="PWINBIO_VERIFY_CALLBACK"/>/<see cref="WinBioVerifyWithCallback"/> combination. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call WinBioVerify. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="VerifyCallbackContext">Pointer to a buffer defined by the application and passed to the VerifyCallbackContext parameter of the WinBioVerifyWithCallback function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.</param>
        /// <param name="OperationStatus">Error code returned by the capture operation.</param>
        /// <param name="UnitId">Biometric unit ID number.</param>
        /// <param name="Match">A Boolean value that specifies whether the captured sample matched the user identity specified by the Identity parameter.</param>
        /// <param name="RejectDetail">Additional information about the failure, if any, to perform the operation. For more information, see Remarks.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WINBIO_VERIFY_CALLBACK([In] PVOID VerifyCallbackContext,
                                                    [In] HRESULT OperationStatus,
                                                    [In] WINBIO_UNIT_ID UnitId,
                                                    [In] BOOLEAN Match,
                                                    [In] WINBIO_REJECT_DETAIL RejectDetail);

        #endregion

        #region Enumerations

        /// <summary>
        /// Defines constants that specify how completion notifications for asynchronous operations are to be delivered to the client application. This enumeration is used by the <see cref="WinBioAsyncOpenFramework"/> and <see cref="WinBioAsyncOpenSession"/> functions.
        /// </summary>
        public enum WINBIO_ASYNC_NOTIFICATION_METHOD
        {

            /// <summary>
            /// The operation is synchronous.
            /// </summary>
            WINBIO_ASYNC_NOTIFY_NONE = 0,

            /// <summary>
            /// The client-implemented PWINBIO_ASYNC_COMPLETION_CALLBACK function is called by the framework.
            /// </summary>
            WINBIO_ASYNC_NOTIFY_CALLBACK,

            /// <summary>
            /// The framework sends completion notices to the client application window message queue.
            /// </summary>
            WINBIO_ASYNC_NOTIFY_MESSAGE,

            /// <summary>
            /// The maximum enumeration value. This constant is not directly used by the WinBioAsyncOpenFramework and WinBioAsyncOpenSession.
            /// </summary>
            WINBIO_ASYNC_NOTIFY_MAXIMUM_VALUE

        }

        /// <summary>
        /// Defines flags that can be used to specify the end-user credential format. This enumeration is used by the <see cref="WinBioSetCredential"/> function.
        /// </summary>
        public enum WINBIO_CREDENTIAL_FORMAT
        {

            /// <summary>
            /// The password is in a generic format.
            /// </summary>
            WINBIO_PASSWORD_GENERIC = 0x00000001,

            /// <summary>
            /// The password is in a compressed format.
            /// </summary>
            WINBIO_PASSWORD_PACKED = 0x00000002,

            /// <summary>
            /// The password credential was wrapped with <see cref="CredProtect"/>.
            /// </summary>
            WINBIO_PASSWORD_PROTECTED = 0x00000003

        }

        /// <summary>
        /// Defines flags that can be used to filter on the credential type. This enumeration is used by the <see cref="WinBioSetCredential"/>, <see cref="WinBioRemoveCredential"/>, and <see cref="WinBioGetCredentialState"/> functions.
        /// </summary>
        public enum WINBIO_CREDENTIAL_TYPE : uint
        {

            /// <summary>
            /// Filters password credentials.
            /// </summary>
            WINBIO_CREDENTIAL_PASSWORD = 0x00000001,

            /// <summary>
            /// Filters all credentials.
            /// </summary>
            WINBIO_CREDENTIAL_ALL = 0xffffffff

        }

        /// <summary>
        /// Defines values that specify whether a credential has been associated with the biometric data for an end user. This enumeration is used by the <see cref="WinBioGetCredentialState"/> function.
        /// </summary>
        public enum WINBIO_CREDENTIAL_STATE
        {

            /// <summary>
            /// A credential has been associated with the end user.
            /// </summary>
            WINBIO_CREDENTIAL_NOT_SET = 0x00000001,

            /// <summary>
            /// A credential has not been associated with the end user.
            /// </summary>
            WINBIO_CREDENTIAL_SET = 0x00000002

        }

        #endregion

        #region Methods

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, string[] Arguments);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr hMem);

        /// <summary>
        /// Acquires window focus.
        /// </summary>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The calling process must be running under the Local System account.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioAcquireFocus();

        /// <summary>
        /// Asynchronously enumerates all attached biometric units that match the input factor type. For a synchronous version of this function, see <see cref="WinBioEnumBiometricUnits"/>.
        /// </summary>
        /// <param name="FrameworkHandle">Handle to the framework session opened by calling <see cref="WinBioAsyncOpenFramework"/>.</param>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> flags that specifies the biometric unit types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <returns>
        /// <para>The function returns an HRESULT indicating success or failure. Note that success indicates only that the arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a <see cref="WINBIO_ASYNC_RESULT"/> structure using the notification method specified in the call to <see cref="WinBioAsyncOpenFramework"/>.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>You must set the <paramref name="FrameworkHandle"/> argument.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the <paramref name="Factor"/> parameter contains one or more an invalid type bits.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There was insufficient memory to complete the request.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the Windows Biometric Framework API.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INCORRECT_SESSION_TYPE"/></term>
        /// <description>The <paramref name="FrameworkHandle"/> argument must represent an asynchronous framework session.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_SESSION_HANDLE_CLOSED"/></term>
        /// <description>The session handle has been marked for closure.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioAsyncEnumBiometricUnits([In] WINBIO_FRAMEWORK_HANDLE FrameworkHandle,
                                                                   [In] WINBIO_BIOMETRIC_TYPE Factor);

        /// <summary>
        /// Asynchronously enumerates all registered databases that match a specified type. For a synchronous version of this function, see <see cref="WinBioEnumDatabases"/>.
        /// </summary>
        /// <param name="FrameworkHandle">Handle to the framework session opened by calling <see cref="WinBioAsyncOpenFramework"/>.</param>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> flags that specifies the biometric database types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <returns>
        /// <para>The function returns an HRESULT indicating success or failure. Note that success indicates only that the arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a WINBIO_ASYNC_RESULT structure using the notification method specified in the call to WinBioAsyncOpenFramework.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>You must set the <paramref name="FrameworkHandle"/> argument.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the <paramref name="Factor"/> parameter contains one or more an invalid type bits.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There was insufficient memory to complete the request.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INCORRECT_SESSION_TYPE"/></term>
        /// <description>The <paramref name="FrameworkHandle"/> argument must represent an asynchronous framework session.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioAsyncEnumDatabases([In] WINBIO_FRAMEWORK_HANDLE FrameworkHandle,
                                                              [In] WINBIO_BIOMETRIC_TYPE Factor);

        /// <summary>
        /// Asynchronously returns information about installed biometric service providers. For a synchronous version of this function, see <see cref="WinBioEnumServiceProviders"/>.
        /// </summary>
        /// <param name="FrameworkHandle">Handle to the framework session opened by calling <see cref="WinBioAsyncOpenFramework"/>.</param>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> flags that specifies the biometric service provider types to be enumerated. For Windows 8, only <see cref="WINBIO_TYPE_FINGERPRINT"/> is supported.</param>
        /// <returns>
        /// <para>The function returns an HRESULT indicating success or failure. Note that success indicates only that the arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a WINBIO_ASYNC_RESULT structure using the notification method specified in the call to WinBioAsyncOpenFramework.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>You must set the <paramref name="FrameworkHandle"/> argument.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the <paramref name="Factor"/> parameter contains one or more an invalid type bits.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There was insufficient memory to complete the request.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INCORRECT_SESSION_TYPE"/></term>
        /// <description>The <paramref name="FrameworkHandle"/> argument must represent an asynchronous framework session.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioAsyncEnumServiceProviders([In] WINBIO_FRAMEWORK_HANDLE FrameworkHandle,
                                                                     [In] WINBIO_BIOMETRIC_TYPE Factor);

        /// <summary>
        /// Starts an asynchronous monitor of changes to the biometric framework. Currently, the only monitored changes that are supported occur when a biometric unit is attached to or detached from the computer.
        /// </summary>
        /// <param name="FrameworkHandle">Handle to the framework session opened by calling <see cref="WinBioAsyncOpenFramework"/>.</param>
        /// <param name="ChangeTypes">
        /// <para>A bitmask of type <see cref="WINBIO_FRAMEWORK_CHANGE_TYPE"/> flags that indicates the types of events that should generate asynchronous notifications. Beginning with Windows 8, the following flag is available:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_FRAMEWORK_CHANGE_UNIT"/></term>
        /// <description>A biometric unit has been attached to or detached from the computer.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>The function returns an HRESULT indicating success or failure. Note that success indicates only that the arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a WINBIO_ASYNC_RESULT structure using the notification method specified in the call to WinBioAsyncOpenFramework.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>You must set the <paramref name="FrameworkHandle"/> argument.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the <paramref name="ChangeTypes"/> parameter contains one or more an invalid type bits. Currently, the only available value is <see cref="WINBIO_FRAMEWORK_CHANGE_UNIT"/>.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INCORRECT_SESSION_TYPE"/></term>
        /// <description>The <paramref name="FrameworkHandle"/> argument must represent an asynchronous framework session.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioAsyncMonitorFrameworkChanges([In] WINBIO_FRAMEWORK_HANDLE FrameworkHandle,
                                                                        [In] WINBIO_FRAMEWORK_CHANGE_TYPE ChangeTypes);

        /// <summary>
        /// Opens a handle to the biometric framework. You can use this handle to asynchronously enumerate biometric units, databases, and service providers and to receive asynchronous notification when biometric units are attached to the computer or removed.
        /// </summary>
        /// <param name="NotificationMethod">
        /// <para>Specifies how completion notifications for asynchronous operations in this framework session are to be delivered to the client application. This must be one of the following values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/></term>
        /// <description>The framework invokes the callback function defined by the application.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_ASYNC_NOTIFY_MESSAGE"/></term>
        /// <description>The framework posts a window message to the application's message queue.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="TargetWindow">Handle of the window that will receive the completion notices. This value is ignored unless the <paramref name="NotificationMethod"/> parameter is set to WINBIO_ASYNC_NOTIFY_MESSAGE.</param>
        /// <param name="MessageCode">
        /// <para>Window message code the framework must send to signify completion notices. This value is ignored unless the <paramref name="NotificationMethod"/> parameter is set to WINBIO_ASYNC_NOTIFY_MESSAGE. The value must be within the range WM_APP(0x8000) to 0xBFFF.</para>
        /// <para>The Windows Biometric Framework sets the LPARAM value of the message to the address of the WINBIO_ASYNC_RESULT structure that contains the results of the operation. You must call WinBioFree to release the structure after you have finished using it.</para>
        /// </param>
        /// <param name="CallbackRoutine">Address of the callback routine to be invoked for completion notices. This value is ignored unless the <paramref name="NotificationMethod"/> parameter is set to WINBIO_ASYNC_NOTIFY_CALLBACK.</param>
        /// <param name="UserData">Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. It is returned in the WINBIO_ASYNC_RESULT structure. Your application can use the data to help it determine what actions to perform upon receipt of the completion notice or to maintain additional information about the requested operation.</param>
        /// <param name="AsynchronousOpen">
        /// <para>Specifies whether to block until the framework session has been opened. Specifying FALSE causes the process to block. Specifying TRUE causes the session to be opened asynchronously.</para>
        /// <para>If you specify FALSE to open the framework session synchronously, success or failure is returned to the caller directly by this function in the HRESULT return value. If the session is opened successfully, the first asynchronous completion event your application receives will be for an asynchronous operation requested after the framework has been open.</para>
        /// <para>If you specify TRUE to open the framework session asynchronously, the first asynchronous completion notice received will be for opening the framework. If the <paramref name="NotificationMethod"/> parameter is set to WINBIO_ASYNC_NOTIFY_CALLBACK, operation results are delivered to the WINBIO_ASYNC_RESULT structure in the callback function specified by the <paramref name="CallbackRoutine"/> parameter. If the <paramref name="NotificationMethod"/> parameter is set to WINBIO_ASYNC_NOTIFY_MESSAGE, operation results are delivered to the WINBIO_ASYNC_RESULT structure pointed to by the LPARAM field of the window message.</para>
        /// </param>
        /// <param name="FrameworkHandle">
        /// <para>If the function does not succeed, this parameter will be NULL.</para>
        /// <para>If the session is opened synchronously and successfully, this parameter will contain a pointer to the session handle.</para>
        /// <para>If you specify that the session be opened asynchronously, this method returns immediately, the session handle will be NULL, and you must examine the WINBIO_ASYNC_RESULT structure to determine whether the session was successfully opened.</para>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There is not enough memory available to create the framework session.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>If you set the notification method to <see cref="WINBIO_ASYNC_NOTIFY_MESSAGE"/>, the <paramref name="TargetWindow"/> parameter cannot be NULL or HWND_BROADCAST and the <paramref name="MessageCode"/> parameter cannot be zero (0).</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>
        /// <para>The <paramref name="FrameworkHandle"/> parameter and the <paramref name="AsynchronousOpen"/> parameter must be set.</para>
        /// <para>If you set the notification method to <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/>, you must also specify the address of a callback function in the <paramref name="CallbackRoutine"/> parameter.</para>
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioAsyncOpenFramework([In] WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod,
                                                              [In] HWND TargetWindow,
                                                              [In] UINT MessageCode,
                                                              [In] WINBIO_ASYNC_COMPLETION_CALLBACK CallbackRoutine,
                                                              [In] PVOID UserData,
                                                              [In] BOOL AsynchronousOpen,
                                                              [Out] out WINBIO_FRAMEWORK_HANDLE FrameworkHandle);

        /// <summary>
        /// <para>Asynchronously connects to a biometric service provider and one or more biometric units. If successful, the function returns a biometric session handle. Every operation performed by using this handle will be completed asynchronously, including <see cref="WinBioCloseSession"/>, and the results will be returned to the client application by using the method specified in the <paramref name="NotificationMethod"/> parameter.</para>
        /// <para>For a synchronous version of this function, see <see cref="WinBioOpenSession"/>.</para>
        /// </summary>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> <paramref name="flags"/> that specifies the biometric unit types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <param name="PoolType">
        /// <para>A ULONG value that specifies the type of the biometric units that will be used in the session. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_POOL_SYSTEM"/></term>
        /// <description>The session connects to a shared collection of biometric units managed by the service provider.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_POOL_PRIVATE"/></term>
        /// <description>The session connects to a collection of biometric units that are managed by the caller.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="Flags">
        /// <para>A ULONG value that specifies biometric unit configuration and access characteristics for the new session. Configuration <paramref name="flags"/> specify the general configuration of units in the session. Access <paramref name="flags"/> specify how the application will use the biometric units. You must specify one configuration flag but you can combine that flag with any access flag.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_DEFAULT"/></term>
        /// <description>
        /// <para>Group: configuration</para>
        /// <para>The biometric units operate in the manner specified during installation. You must use this value when the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>.</para>
        /// </description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_BASIC"/></term>
        /// <description>
        /// <para>Group: configuration</para>
        /// <para>The biometric units operate only as basic capture devices. All processing, matching, and storage operations is performed by software plug-ins.</para>
        /// </description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_ADVANCED"/></term>
        /// <description>
        /// <para>Group: configuration</para>
        /// <para>The biometric units use internal processing and storage capabilities.</para>
        /// </description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_RAW"/></term>
        /// <description>
        /// <para>Group: access</para>
        /// <para>The client application captures raw biometric data using <see cref="WinBioCaptureSample"/>.</para>
        /// </description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_MAINTENANCE"/></term>
        /// <description>
        /// <para>Group: access</para>
        /// <para>The client performs vendor-defined control operations on a biometric unit by calling <see cref="WinBioControlUnitPrivileged"/>.</para>
        /// </description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="UnitArray">Pointer to an array of biometric unit identifiers to be included in the session. You can call <see cref="WinBioEnumBiometricUnits"/> to enumerate the biometric units. Set this value to NULL if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>.</param>
        /// <param name="UnitCount">A value that specifies the number of elements in the array pointed to by the <paramref name="UnitArray"/> parameter. Set this value to zero if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>.</param>
        /// <param name="DatabaseId">
        /// <para>A value that specifies the database(s) to be used by the session. If the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_PRIVATE"/>, you must specify the GUID of an installed database. If the <paramref name="PoolType"/> parameter is not <see cref="WINBIO_POOL_PRIVATE"/>, you can specify one of the following common values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_DB_DEFAULT"/></term>
        /// <description>Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration. You must specify this value if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>. You cannot use this value if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_PRIVATE"/></description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_DB_BOOTSTRAP"/></term>
        /// <description>You can specify this value to be used for scenarios prior to starting Windows. Typically, the database is part of the sensor chip or is part of the BIOS and can only be used for template enrollment and deletion.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_DB_ONCHIP"/></term>
        /// <description>The database is on the sensor chip and is available for enrollment and matching.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="NotificationMethod">
        /// <para>Specifies how completion notifications for asynchronous operations in this biometric session are to be delivered to the client application. This must be one of the following values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/></term>
        /// <description>The session invokes the callback function defined by the application.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_ASYNC_NOTIFY_MESSAGE"/></term>
        /// <description>The session posts a window message to the application's message queue.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="TargetWindow">Handle of the window that will receive the completion notices. This value is ignored unless the <paramref name="NotificationMethod"/> parameter is set to <see cref="WINBIO_ASYNC_NOTIFY_MESSAGE"/>.</param>
        /// <param name="MessageCode">
        /// <para>Window message code the framework must send to signify completion notices. This value is ignored unless the <paramref name="NotificationMethod"/> parameter is set to <see cref="WINBIO_ASYNC_NOTIFY_MESSAGE"/>. The value must be within the range <see cref="WM_APP"/>(0x8000) to 0xBFFF.</para>
        /// <para>The Windows Biometric Framework sets the LPARAM value of the message to the address of the <see cref="WINBIO_ASYNC_RESULT"/> structure that contains the results of the operation. You must call <see cref="WinBioFree"/> to release the structure after you have finished using it.</para>
        /// </param>
        /// <param name="CallbackRoutine">
        /// <para>Address of callback routine to be invoked when the operation started by using the session handle completes. This value is ignored unless the <paramref name="NotificationMethod"/> parameter is set to <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/>.</para>
        /// </param>
        /// <param name="UserData">Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. It is returned in the <see cref="WINBIO_ASYNC_RESULT"/> structure. Your application can use the data to help it determine what actions to perform upon receipt of the completion notice or to maintain additional information about the requested operation.</param>
        /// <param name="AsynchronousOpen">
        /// <para>Specifies whether to block until the framework session has been opened. Specifying FALSE causes the process to block. Specifying TRUE causes the session to be opened asynchronously.</para>
        /// <para>If you specify FALSE to open the framework session synchronously, success or failure is returned to the caller directly by this function in the HRESULT return value. If the session is opened successfully, the first asynchronous completion event your application receives will be for an asynchronous operation requested after the framework has been open.</para>
        /// <para>If you specify TRUE to open the framework session asynchronously, the first asynchronous completion notice received will be for opening the framework. If the <paramref name="NotificationMethod"/> parameter is set to <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/>, operation results are delivered to the <see cref="WINBIO_ASYNC_RESULT"/> structure in the callback function specified by the <paramref name="CallbackRoutine"/> parameter. If the <paramref name="NotificationMethod"/> parameter is set to <see cref="WINBIO_ASYNC_NOTIFY_MESSAGE"/>, operation results are delivered to the <see cref="WINBIO_ASYNC_RESULT"/> structure pointed to by the LPARAM field of the window message.</para>
        /// </param>
        /// <param name="SessionHandle">
        /// <para>If the function does not succeed, this parameter will be NULL.</para>
        /// <para>If the session is opened synchronously and successfully, this parameter will contain a pointer to the session handle.</para>
        /// <para>If you specify that the session be opened asynchronously, this method returns immediately, the session handle will be NULL, and you must examine the <see cref="WINBIO_ASYNC_RESULT"/> structure to determine whether the session was successfully opened.</para>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There is not enough memory available to create the biometric session.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>If you set the notification method to WINBIO_ASYNC_NOTIFY_MESSAGE, the <paramref name="TargetWindow"/> parameter cannot be NULL or HWND_BROADCAST and the <paramref name="MessageCode"/> parameter cannot be zero (0).</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description><para>The <paramref name="SessionHandle"/> parameter and the <paramref name="AsynchronousOpen"/> parameter must be set.</para>
        /// <para>If you set the notification method to <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/>, you must also specify the address of a callback function in the <paramref name="CallbackRoutine"/> parameter.</para></description>
        /// </item>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The <paramref name="Flags"/> parameter contains the <see cref="WINBIO_FLAG_RAW"/> or the <see cref="WINBIO_FLAG_MAINTENANCE"/> flag and the caller has not been granted either access permission.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INVALID_UNIT"/></term>
        /// <description>One or more of the biometric unit numbers specified in the <paramref name="UnitArray"/> parameter is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_NOT_ACTIVE_CONSOLE"/></term>
        /// <description>The client application is running on a remote desktop client and is attempting to open a system pool session.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_SENSOR_UNAVAILABLE"/></term>
        /// <description>The <paramref name="PoolType"/> parameter is set to <see cref="WINBIO_POOL_PRIVATE"/> and one or more of the requested sensors in that pool is not available.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the Windows Biometric Framework API.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioAsyncOpenSession([In] WINBIO_BIOMETRIC_TYPE Factor,
                                                                   [In] WINBIO_POOL_TYPE PoolType,
                                                                   [In] WINBIO_SESSION_FLAGS Flags,
                                                                   [In] WINBIO_UNIT_ID* UnitArray,
                                                                   [In] SIZE_T UnitCount,
                                                                   [In] Guid* DatabaseId,
                                                                   [In] WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod,
                                                                   [In] HWND TargetWindow,
                                                                   [In] UINT MessageCode,
                                                                   [In] WINBIO_ASYNC_COMPLETION_CALLBACK CallbackRoutine,
                                                                   [In] PVOID UserData,
                                                                   [In] BOOL AsynchronousOpen,
                                                                   [Out] out WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// Cancels all pending biometric operations for a specified session.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioCancel([In]  WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// Captures a biometric sample and fills a biometric information record (BIR) with the raw or processed data.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="Purpose">
        /// <para>A <see cref="WINBIO_BIR_PURPOSE"/> bitmask that specifies the intended use of the sample. This can be a bitwise OR of the following values:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_VERIFY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_IDENTIFY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_ENROLL"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="Flags">
        /// <para>A value that specifies the type of processing to be applied to the captured sample. This can be a bitwise OR of the following security and processing level flags:</para>
        /// <para><see cref="WINBIO_DATA_FLAG_PRIVACY"/> (Encrypt the sample.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_INTEGRITY"/> (Sign the sample or protect it by using a message authentication code (MAC).)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_SIGNED"/> (If this flag and the WINBIO_DATA_FLAG_INTEGRITY flag are set, sign the sample. If this flag is not set but the WINBIO_DATA_FLAG_INTEGRITY flag is set, compute a MAC.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_RAW"/> (Return the sample exactly as it was captured by the sensor.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_INTERMEDIATE"/> (Return the sample after it has been cleaned and filtered.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_PROCESSED"/> (Return the sample after it is ready to be used for the purpose specified by the Purpose parameter.)</para>
        /// </param>
        /// <param name="UnitId">A pointer to a <see cref="WINBIO_UNIT_ID"/> value that contains the ID of the biometric unit that generated the sample.</param>
        /// <param name="Sample">Address of a variable that receives a pointer to a <see cref="WINBIO_BIR"/> structure that contains the sample. When you have finished using the structure, you must pass the pointer to <see cref="WinBioFree"/> to release the memory allocated for the sample.</param>
        /// <param name="SampleSize">A pointer to a SIZE_T value that contains the size, in bytes, of the <see cref="WINBIO_BIR"/> structure returned in the Sample parameter.</param>
        /// <param name="RejectDetail">
        /// <para>A pointer to a <see cref="WINBIO_REJECT_DETAIL"/> value that contains additional information about the failure to capture a biometric sample. If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_HIGH"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LEFT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_RIGHT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_FAST"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SLOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_POOR_QUALITY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SKEWED"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SHORT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_MERGE_FAILURE"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to capture raw samples, or the session was not opened by using the <see cref="WINBIO_FLAG_RAW"/> flag.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_NOTIMPL"/></term>
        /// <description>The biometric unit does not support the requested operation.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="UnitId"/>, <paramref name="Sample"/>, <paramref name="SampleSize"/>, and <paramref name="RejectDetail"/> pointers cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioCaptureSample([In]      WINBIO_SESSION_HANDLE SessionHandle,
                                                         [In]      WINBIO_BIR_PURPOSE Purpose,
                                                         [In]      WINBIO_BIR_DATA_FLAGS Flags,
                                                         [Out] out WINBIO_UNIT_ID UnitId,
                                                         [Out] out IntPtr Sample,
                                                         [Out] out SIZE_T SampleSize,
                                                         [Out] out WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// <para>Captures a biometric sample asynchronously and returns the raw or processed data in a biometric information record (BIR). The function returns immediately to the caller, captures the sample on a separate thread, and calls into an application-defined callback function to update operation status.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the <paramref name="CallbackRoutine"/> parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the <paramref name="NotificationMethod"/> parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioCaptureSample"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session.</param>
        /// <param name="Purpose">
        /// <para>A <see cref="WINBIO_BIR_PURPOSE"/> bitmask that specifies the intended use of the sample. This can be a bitwise OR of the following values:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_VERIFY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_IDENTIFY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_ENROLL"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="Flags">
        /// <para>A value that specifies the type of processing to be applied to the captured sample. This can be a bitwise OR of the following security and processing level flags:</para>
        /// <para><see cref="WINBIO_DATA_FLAG_PRIVACY"/> (Encrypt the sample.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_INTEGRITY"/> (Sign the sample or protect it by using a message authentication code (MAC).)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_SIGNED"/> (If this flag and the WINBIO_DATA_FLAG_INTEGRITY flag are set, sign the sample. If this flag is not set but the WINBIO_DATA_FLAG_INTEGRITY flag is set, compute a MAC.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_RAW"/> (Return the sample exactly as it was captured by the sensor.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_INTERMEDIATE"/> (Return the sample after it has been cleaned and filtered.)</para>
        /// <para><see cref="WINBIO_DATA_FLAG_PROCESSED"/> (Return the sample after it is ready to be used for the purpose specified by the Purpose parameter.)</para>
        /// </param>
        /// <param name="CaptureCallback">Address of a callback function that will be called by the <see cref="WinBioCaptureSampleWithCallback"/> function when the capture operation succeeds or fails. You must create the callback.</param>
        /// <param name="CaptureCallbackContext">Address of an application-defined data structure that is passed to the callback function in its <paramref name="CaptureCallbackContext"/> parameter. This structure can contain any data that the custom callback function is designed to handle.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to capture raw samples, or the session was not opened by using the <see cref="WINBIO_FLAG_RAW"/> flag.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_NOTIMPL"/></term>
        /// <description>The biometric unit does not support the requested operation.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="UnitId"/>, <paramref name="Sample"/>, <paramref name="SampleSize"/>, and <paramref name="RejectDetail"/> pointers cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioCaptureSampleWithCallback([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                     [In] WINBIO_BIR_PURPOSE Purpose,
                                                                     [In] WINBIO_BIR_DATA_FLAGS Flags,
                                                                     [In] WINBIO_CAPTURE_CALLBACK CaptureCallback,
                                                                     [In] PVOID CaptureCallbackContext);

        /// <summary>
        /// Closes a framework handle previously opened with <see cref="WinBioAsyncOpenFramework"/>.
        /// </summary>
        /// <param name="FrameworkHandle">Handle to the framework session that will be closed.</param>
        /// <returns>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error.</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioCloseFramework([In] WINBIO_FRAMEWORK_HANDLE FrameworkHandle);

        /// <summary>
        /// Closes a biometric session and releases associated resources.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioCloseSession([In]  WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// Allows the caller to perform vendor-defined control operations on a biometric unit. This function is provided for access to extended vendor operations for which elevated privileges are not required. If access rights are required, call the <see cref="WinBioControlUnitPrivileged"/> function.
        /// </summary>
        /// <param name="SessionHandle">A WINBIO_SESSION_HANDLE value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <seWinBioAsyncOpenSession.</param>
        /// <param name="UnitId">A <see cref="WINBIO_UNIT_ID"/> value that identifies the biometric unit. This value must correspond to the unit ID used previously in the <see cref="WinBioLockUnit"/> function.</param>
        /// <param name="Component">
        /// <para>A WINBIO_COMPONENT value that specifies the component within the biometric unit that should perform the operation. This can be one of the following values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_COMPONENT_SENSOR"/></term>
        /// <description>Send the command to the sensor adapter.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_COMPONENT_ENGINE"/></term>
        /// <description>Send the command to the engine adapter.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_COMPONENT_STORAGE"/></term>
        /// <description>Send the command to the storage adapter.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="ControlCode">A vendor-defined code recognized by the biometric unit specified by the <paramref name="UnitId"/> parameter and the adapter specified by the <paramref name="Component"/> parameter.</param>
        /// <param name="SendBuffer">Address of the buffer that contains the control information to be sent to the adapter specified by the <paramref name="Component"/> parameter. The format and content of the buffer is vendor-defined.</param>
        /// <param name="SendBufferSize">Size, in bytes, of the buffer specified by the <paramref name="SendBuffer"/> parameter.</param>
        /// <param name="ReceiveBuffer">Address of the buffer that receives information sent by the adapter specified by the <paramref name="Component"/> parameter. The format and content of the buffer is vendor-defined.</param>
        /// <param name="ReceiveBufferSize">Size, in bytes, of the buffer specified by the <paramref name="ReceiveBuffer"/> parameter.</param>
        /// <param name="ReceiveDataSize">Pointer to a SIZE_T value that contains the size, in bytes, of the data written to the buffer specified by the <paramref name="ReceiveBuffer"/> parameter.</param>
        /// <param name="OperationStatus">Pointer to an integer that contains a vendor-defined status code that specifies the outcome of the control operation.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The value specified in the <paramref name="ControlCode"/> parameter is not recognized.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="SendBuffer"/>, <paramref name="ReceiveBuffer"/>, <paramref name="ReceiveDataSize"/>, <paramref name="OperationStatus"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INVALID_CONTROL_CODE"/></term>
        /// <description>The value specified in the <paramref name="ControlCode"/> parameter is not recognized.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit specified by the <paramref name="UnitId"/> parameter must be locked before any control operations can be performed.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioControlUnit([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                       [In] WINBIO_UNIT_ID UnitId,
                                                       [In] WINBIO_COMPONENT Component,
                                                       [In] ULONG ControlCode,
                                                       [In] PUCHAR SendBuffer,
                                                       [In] SIZE_T SendBufferSize,
                                                       [Out] out PUCHAR ReceiveBuffer,
                                                       [In] SIZE_T ReceiveBufferSize,
                                                       [Out] out SIZE_T ReceiveDataSize,
                                                       [Out] out ULONG OperationStatus);

        /// <summary>
        /// Allows the caller to perform privileged vendor-defined control operations on a biometric unit. The client must call this function to perform extended vendor operations that require elevated access rights. If no privileges are required, the client can call the <see cref="WinBioControlUnit"/> function.
        /// </summary>
        /// <param name="SessionHandle">A WINBIO_SESSION_HANDLE value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <seWinBioAsyncOpenSession.</param>
        /// <param name="UnitId">A <see cref="WINBIO_UNIT_ID"/> value that identifies the biometric unit. This value must correspond to the unit ID used previously in the <see cref="WinBioLockUnit"/> function.</param>
        /// <param name="Component">
        /// <para>A WINBIO_COMPONENT value that specifies the component within the biometric unit that should perform the operation. This can be one of the following values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_COMPONENT_SENSOR"/></term>
        /// <description>Send the command to the sensor adapter.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_COMPONENT_ENGINE"/></term>
        /// <description>Send the command to the engine adapter.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_COMPONENT_STORAGE"/></term>
        /// <description>Send the command to the storage adapter.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="ControlCode">A vendor-defined code recognized by the biometric unit specified by the <paramref name="UnitId"/> parameter and the adapter specified by the <paramref name="Component"/> parameter.</param>
        /// <param name="SendBuffer">Address of the buffer that contains the control information to be sent to the adapter specified by the <paramref name="Component"/> parameter. The format and content of the buffer is vendor-defined.</param>
        /// <param name="SendBufferSize">Size, in bytes, of the buffer specified by the <paramref name="SendBuffer"/> parameter.</param>
        /// <param name="ReceiveBuffer">Address of the buffer that receives information sent by the adapter specified by the <paramref name="Component"/> parameter. The format and content of the buffer is vendor-defined.</param>
        /// <param name="ReceiveBufferSize">Size, in bytes, of the buffer specified by the <paramref name="ReceiveBuffer"/> parameter.</param>
        /// <param name="ReceiveDataSize">Pointer to a SIZE_T value that contains the size, in bytes, of the data written to the buffer specified by the <paramref name="ReceiveBuffer"/> parameter.</param>
        /// <param name="OperationStatus">Pointer to an integer that contains a vendor-defined status code that specifies the outcome of the control operation.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The value specified in the <paramref name="ControlCode"/> parameter is not recognized.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="SendBuffer"/>, <paramref name="ReceiveBuffer"/>, <paramref name="ReceiveDataSize"/>, <paramref name="OperationStatus"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to perform the operation, or the session was not opened by using <see cref="WINBIO_FLAG_MAINTENANCE"/>.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The value specified in the <paramref name="ControlCode"/> parameter is not recognized.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit specified by the <paramref name="UnitId"/> parameter must be locked before any control operations can be performed.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioControlUnitPrivileged([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                 [In] WINBIO_UNIT_ID UnitId,
                                                                 [In] WINBIO_COMPONENT Component,
                                                                 [In] ULONG ControlCode,
                                                                 [In] PUCHAR SendBuffer,
                                                                 [In] SIZE_T SendBufferSize,
                                                                 [Out] out PUCHAR ReceiveBuffer,
                                                                 [In] SIZE_T ReceiveBufferSize,
                                                                 [Out] out SIZE_T ReceiveDataSize,
                                                                 [Out] out ULONG OperationStatus);

        /// <summary>
        /// Deletes a biometric template from the template store.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="UnitId">A <see cref="WINBIO_UNIT_ID"/> value that identifies the biometric unit where the template is located.</param>
        /// <param name="Identity">Pointer to a <see cref="WINBIO_IDENTITY"/> structure that contains the GUID or SID of the template to be deleted. If the Type member of the <see cref="WINBIO_IDENTITY"/> structure is <see cref="WINBIO_ID_TYPE_WILDCARD"/>, templates matching the <paramref name="SubFactor"/> parameter will be deleted for all identities. Only administrators can perform wildcard identity deletion.</param>
        /// <param name="SubFactor">A <see cref="WINBIO_BIOMETRIC_SUBTYPE"/> value that provides additional information about the template to be deleted. If you specify <see cref="WINBIO_SUBTYPE_ANY"/>, all templates for the biometric unit specified by the <paramref name="UnitId"/> parameter are deleted.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="UnitId"/> parameter contains zero or the SubFactor contains <see cref="WINBIO_SUBTYPE_NO_INFORMATION"/>.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified in the <paramref name="Identity"/> parameter cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the biometric unit is currently being used for an enrollment transaction.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern HRESULT WinBioDeleteTemplate([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                 [In] WINBIO_UNIT_ID UnitId,
                                                                 [In] WINBIO_IDENTITY* Identity,
                                                                 [In] WINBIO_BIOMETRIC_SUBTYPE SubFactor);

        /// <summary>
        /// <para>Asynchronously captures a biometric sample and adds it to a template. The function returns immediately to the caller, performs enrollment on a separate thread, and calls into an application-defined callback function to update operation status.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioEnrollCapture"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session.</param>
        /// <param name="EnrollCallback">Address of a callback function that will be called by the <see cref="WinBioEnrollCaptureWithCallback"/> function when the capture operation succeeds or fails. You must create the callback.</param>
        /// <param name="EnrollCallbackContext">Pointer to an optional application-defined structure that is passed to the <paramref name="EnrollCallbackContext"/> parameter of the callback function. This structure can contain any data that the custom callback function is designed to handle.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The calling account is not allowed to perform enrollment.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified by the <paramref name="EnrollCallback"/> parameter cannot be NULL.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnrollCaptureWithCallback([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                     [In] WINBIO_ENROLL_CAPTURE_CALLBACK EnrollCallback,
                                                                     [In] PVOID EnrollCallbackContext);

        /// <summary>
        /// Initiates a biometric enrollment sequence and creates an empty biometric template.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="SubFactor">
        /// <para>A <see cref="WINBIO_BIOMETRIC_SUBTYPE"/> value that provides additional information about the enrollment. This must be one of the following values:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_THUMB"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_INDEX_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_RING_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_LITTLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_THUMB"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_INDEX_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_RING_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_LITTLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_FOUR_FINGERS"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_FOUR_FINGERS"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="UnitId">A <see cref="WINBIO_UNIT_ID"/> value that identifies the biometric unit. This value cannot be zero. You can find a unit ID by calling the <see cref="WinBioEnumBiometricUnits"/> or <see cref="WinBioLocateSensor"/> functions.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to enroll.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The SubFactor parameter cannot equal <see cref="WINBIO_SUBTYPE_NO_INFORMATION"/> or <see cref="WINBIO_SUBTYPE_ANY"/>, and the <paramref name="UnitId"/> parameter cannot equal zero.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>An enrollment operation is already in progress, and only one enrollment can occur at a given time.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit is in use and is locked.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnrollBegin([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                       [In] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
                                                       [In] WINBIO_UNIT_ID UnitId);

        /// <summary>
        /// Captures a biometric sample and adds it to a template.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="RejectDetail">
        /// <para>A pointer to a ULONG value that contains additional information the failure to capture a biometric sample. If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_HIGH"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LEFT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_RIGHT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_FAST"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SLOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_POOR_QUALITY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SKEWED"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SHORT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_MERGE_FAILURE"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The calling account is not allowed to perform enrollment.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified by the <paramref name="RejectDetail"/> parameter cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_BAD_CAPTURE"/></term>
        /// <description>The sample could not be captured. Use the <paramref name="RejectDetail"/> value for more information.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit is in use and is locked.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_I_MORE_DATA"/></term>
        /// <description>The matching engine requires one or more additional samples to generate a reliable template. You should update instructions to the user to submit more samples and call <see cref="WinBioEnrollCapture"/> again.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnrollCapture([In]  WINBIO_SESSION_HANDLE SessionHandle,
                                                         [Out] out WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// Finalizes a pending biometric template and saves it to the database associated with the biometric unit used for enrollment.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="Identity">Pointer to a <see cref="WINBIO_IDENTITY"/> structure that receives the identifier (GUID or SID) of the template.</param>
        /// <param name="IsNewTemplate">Pointer to a Boolean value that specifies whether the template being added to the database is new.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointers specified by the <paramref name="Identity"/> and <paramref name="IsNewTemplate"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_DATABASE_FULL"/></term>
        /// <description>There is no space available in the database for the template.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_DUPLICATE_TEMPLATE"/></term>
        /// <description>The template matches one already saved in the database with a different identity or sub-factor (system pool only).</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit is in use and is locked.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnrollCommit([In]      WINBIO_SESSION_HANDLE SessionHandle,
                                                        [Out] out WINBIO_IDENTITY Identity,
                                                        [Out] out BOOLEAN IsNewTemplate);

        /// <summary>
        /// Ends the enrollment sequence and discards a pending biometric template.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to enroll.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit is in use and is locked.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnrollDiscard([In] WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// Enumerates all attached biometric units that match the input type.
        /// </summary>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> flags that specifies the biometric unit types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <param name="UnitSchemaArray">Address of a variable that receives a pointer to an array of <see cref="WINBIO_UNIT_SCHEMA"/> structures that contain information about each enumerated biometric unit. If the function does not succeed, the pointer is set to NULL. If the function succeeds, you must pass the pointer to <see cref="WinBioFree"/> to release memory allocated internally for the array.</param>
        /// <param name="UnitCount">Pointer to a value that specifies the number of structures pointed to by the <paramref name="UnitSchemaArray"/> parameter.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the <paramref name="Factor"/> parameter contains one or more an invalid type bits.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There was insufficient memory to complete the request.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="UnitSchemaArray"/> and <paramref name="UnitCount"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the Windows Biometric Framework API.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnumBiometricUnits([In]  WINBIO_BIOMETRIC_TYPE Factor,
                                                              [Out] out WINBIO_UNIT_SCHEMA[] UnitSchemaArray,
                                                              [Out] out SIZE_T UnitCount);

        /// <summary>
        /// Enumerates all registered databases that match a specified type.
        /// </summary>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> flags that specifies the biometric unit types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <param name="StorageSchemaArray">Address of a variable that receives a pointer to an array of <see cref="WINBIO_STORAGE_SCHEMA"/> structures that contain information about each database. If the function does not succeed, the pointer is set to NULL. If the function succeeds, you must pass the pointer to <see cref="WinBioFree"/> to release memory allocated internally for the array.</param>
        /// <param name="StorageCount">Pointer to a value that specifies the number of structures pointed to by the <paramref name="StorageSchemaArray"/> parameter.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There was insufficient memory to complete the request.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="StorageSchemaArray"/> and <paramref name="StorageCount"/> parameters cannot be NULL.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioEnumDatabases([In] WINBIO_BIOMETRIC_TYPE Factor,
                                                                [Out] WINBIO_STORAGE_SCHEMA** StorageSchemaArray,
                                                                [Out] out SIZE_T StorageCount);

        /// <summary>
        /// Retrieves the biometric sub-factors enrolled for a specified identity and biometric unit.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="UnitId">A <see cref="WINBIO_UNIT_ID"/> value that specifies the biometric unit.</param>
        /// <param name="Identity">Pointer to a <see cref="WINBIO_IDENTITY"/> structure that contains the GUID or SID of the template from which the sub-factors are to be retrieved.</param>
        /// <param name="SubFactorArray">Address of a variable that receives a pointer to an array of sub-factors. If the function does not succeed, the pointer is set to NULL. If the function succeeds, you must pass the pointer to <see cref="WinBioFree"/> to release memory allocated internally for the array.</param>
        /// <param name="SubFactorCount">Pointer to a value that specifies the number of elements in the array pointed to by the <paramref name="SubFactorArray"/> parameter. If the function does not succeed, this value is set to zero.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="UnitId"/> parameter cannot be zero.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="Identity"/>, <paramref name="SubFactorArray"/>, and <paramref name="SubFactorCount"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the biometric unit specified by the <paramref name="UnitId"/> parameter is currently being used for an enrollment transaction.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_UNKNOWN_ID"/></term>
        /// <description>The GUID or SID specified by the Identity parameter cannot be found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioEnumEnrollments([In]     WINBIO_SESSION_HANDLE SessionHandle,
                                                                  [In]     WINBIO_UNIT_ID UnitId,
                                                                  [In]     ref WINBIO_IDENTITY Identity,
                                                                  [Out] out WINBIO_BIOMETRIC_SUBTYPE* SubFactorArray,
                                                                  [Out] out SIZE_T SubFactorCount);

        /// <summary>
        /// Retrieves information about installed biometric service providers.
        /// </summary>
        /// <param name="Factor">A bitmask of <see cref="WINBIO_BIOMETRIC_TYPE"/> flags that specifies the biometric unit types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <param name="BspSchemaArray">Address of a variable that receives a pointer to an array of <see cref="WINBIO_BSP_SCHEMA"/> structures that contain information about each of the available service providers. If the function does not succeed, the pointer is set to NULL. If the function succeeds, you must pass the pointer to <see cref="WinBioFree"/> to release memory allocated internally for the array.</param>
        /// <param name="BspCount">Pointer to a value that specifies the number of structures pointed to by the <paramref name="BspSchemaArray"/> parameter.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_OUTOFMEMORY"/></term>
        /// <description>There was insufficient memory to complete the request.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="BspSchemaArray"/> and <paramref name="BspCount"/> parameters cannot be NULL.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioEnumServiceProviders([In] WINBIO_BIOMETRIC_TYPE Factor,
                                                                [Out] out WINBIO_BSP_SCHEMA[] BspSchemaArray,
                                                                [Out] out SIZE_T BspCount);

        /// <summary>
        /// Releases memory allocated for the client application by an earlier call to a Windows Biometric Framework API function.
        /// </summary>
        /// <param name="Address">Address of the memory block to delete.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="Address"/> parameter cannot be NULL.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioFree([In] PVOID Address);

        /// <summary>
        /// Retrieves a value that specifies whether credentials have been set for the specified user.
        /// </summary>
        /// <param name="Identity">A <see cref="WINBIO_IDENTITY"/> structure that contains the SID of the user account for which the credential is being queried.</param>
        /// <param name="Type">
        /// <para>A <see cref="WINBIO_CREDENTIAL_TYPE"/> value that specifies the credential type. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_CREDENTIAL_PASSWORD"/></term>
        /// <description>The password-based credential is checked.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="CredentialState">
        /// <para>Pointer to a <see cref="WINBIO_CREDENTIAL_STATE"/> enumeration value that specifies whether user credentials have been set. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_CREDENTIAL_NOT_SET"/></term>
        /// <description>A credential has not been specified.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_CREDENTIAL_SET"/></term>
        /// <description>A credential has been specified.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to retrieve the credential state.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_UNKNOWN_ID"/></term>
        /// <description>The specified identity does not exist.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_CRED_PROV_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the credential provider.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioGetCredentialState([In] WINBIO_IDENTITY Identity,
                                                              [In] WINBIO_CREDENTIAL_TYPE Type,
                                                              [Out] out WINBIO_CREDENTIAL_STATE CredentialState);

        /// <summary>
        /// Captures a biometric sample and determines whether it matches an existing biometric template.
        /// </summary>
        /// <param name="SessionHandle [in]">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="UnitId [out, optional]">A pointer to a ULONG value that specifies the biometric unit used to perform the identification.</param>
        /// <param name="Identity [out, optional]">Pointer to a <see cref="WINBIO_IDENTITY"/> structure that receives the GUID or SID of the user providing the biometric sample.</param>
        /// <param name="SubFactor [out, optional]">Pointer to a <see cref="WINBIO_BIOMETRIC_SUBTYPE"/> value that receives the sub-factor associated with the biometric sample. See the Remarks section for more details.</param>
        /// <param name="RejectDetail">
        /// <para>A pointer to a <see cref="WINBIO_REJECT_DETAIL"/> value that contains additional information about the failure to capture a biometric sample. If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_HIGH"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LEFT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_RIGHT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_FAST"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SLOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_POOR_QUALITY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SKEWED"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SHORT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_MERGE_FAILURE"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified by the <paramref name="UnitId"/>, <paramref name="Identity"/>, <paramref name="SubFactor"/>, or <paramref name="RejectDetail"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_BAD_CAPTURE"/></term>
        /// <description>The sample could not be captured. Use the <paramref name="RejectDetail"/> value for more information.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_UNKNOWN_ID"/></term>
        /// <description>The biometric sample does not match any saved in the database.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioIdentify([In]      WINBIO_SESSION_HANDLE SessionHandle,
                                                    [Out] out WINBIO_UNIT_ID UnitId,
                                                    [Out] out WINBIO_IDENTITY Identity,
                                                    [Out] out WINBIO_BIOMETRIC_SUBTYPE SubFactor,
                                                    [Out] out WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// <para>Asynchronously captures a biometric sample and determines whether it matches an existing biometric template. The function returns immediately to the caller, performs capture and identification on a separate thread, and calls into an application-defined callback function to update operation status.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioIdentify"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session.</param>
        /// <param name="IdentifyCallback">Address of a callback function that will be called by the <see cref="WinBioIdentifyWithCallback"/> function when identification succeeds or fails. You must create the callback.</param>
        /// <param name="IdentifyCallbackContext">Pointer to an application-defined data structure that is passed to the callback function in its <see cref="IdentifyCallbackContext"/> parameter. This structure can contain any data that the custom callback function is designed to handle.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The SessionHandle and IdentifyCallback parameter</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioIdentifyWithCallback([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                [In] WINBIO_IDENTIFY_CALLBACK IdentifyCallback,
                                                                [In] PVOID IdentifyCallbackContext);

        /// <summary>
        /// Retrieves a value that specifies whether users can log on to a domain by using biometric information.
        /// </summary>
        /// <param name="Value">Pointer to a Boolean value that specifies whether biometric domain logons are enabled.</param>
        /// <param name="Source">
        /// <para>Pointer to a WINBIO_SETTING_SOURCE_TYPE value that specifies the setting source. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_INVALID"/></term>
        /// <description>The setting is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_DEFAULT"/></term>
        /// <description>The setting originated from built-in policy.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_LOCAL"/></term>
        /// <description>The setting originated in the local computer registry.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_POLICY"/></term>
        /// <description>The setting was created by Group Policy.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. For a list of common error codes, see Common HRESULT Values.</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioGetDomainLogonSetting([Out] out BOOLEAN Value,
                                                                 [Out] out WINBIO_SETTING_SOURCE_TYPE Source);

        /// <summary>
        /// Retrieves a value that specifies whether the Windows Biometric Framework is currently enabled.
        /// </summary>
        /// <param name="Value">Pointer to a Boolean value that specifies whether the Windows Biometric Framework is currently enabled.</param>
        /// <param name="Source">
        /// <para>Pointer to a WINBIO_SETTING_SOURCE_TYPE value that specifics the setting source. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_INVALID"/></term>
        /// <description>The setting is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_DEFAULT"/></term>
        /// <description>The setting originated from built-in policy.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_LOCAL"/></term>
        /// <description>The setting originated in the local computer registry.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_POLICY"/></term>
        /// <description>The setting was created by Group Policy.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. For a list of common error codes, see Common HRESULT Values.</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioGetEnabledSetting([Out] out BOOLEAN Value,
                                                             [Out] out WINBIO_SETTING_SOURCE_TYPE Source);

        /// <summary>
        /// Retrieves a value that indicates whether users can log on by using biometric information.
        /// </summary>
        /// <param name="Value">Pointer to a Boolean value that specifies whether biometric logons are enabled.</param>
        /// <param name="Source">
        /// <para>Pointer to a WINBIO_SETTING_SOURCE_TYPE value that specifics the setting source. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_INVALID"/></term>
        /// <description>The setting is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_DEFAULT"/></term>
        /// <description>The setting originated from built-in policy.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_LOCAL"/></term>
        /// <description>The setting originated in the local computer registry.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_SETTING_SOURCE_POLICY"/></term>
        /// <description>The setting was created by Group Policy.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. For a list of common error codes, see Common HRESULT Values.</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioGetLogonSetting([Out] out BOOLEAN Value,
                                                           [Out] out WINBIO_SETTING_SOURCE_TYPE Source);

        /// <summary>
        /// Retrieves a session, unit, or template property.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="PropertyType">A <see cref="WINBIO_PROPERTY_TYPE"/> value that specifies the source of the property information. Currently this must be <see cref="WINBIO_PROPERTY_TYPE_UNIT"/>.</param>
        /// <param name="PropertyId">A <see cref="WINBIO_PROPERTY_ID"/> value that specifies the property to be queried. Currently this must be <see cref="WINBIO_PROPERTY_SAMPLE_HINT"/>.</param>
        /// <param name="UnitId">A <see cref="WINBIO_UNIT_ID"/> value that identifies the biometric unit. This value cannot be zero. You can find a unit ID by calling the <see cref="WinBioEnumBiometricUnits"/> or <see cref="WinBioLocateSensor"/> functions.</param>
        /// <param name="Identity">Reserved. This must be NULL.</param>
        /// <param name="SubFactor">Reserved. This must be <see cref="WINBIO_SUBTYPE_NO_INFORMATION"/>.</param>
        /// <param name="PropertyBuffer">Address of a pointer to a buffer that receives the property value.</param>
        /// <param name="PropertyBufferSize">Pointer to a variable that receives the size, in bytes, of the buffer pointed to by the <paramref name="PropertyBuffer"/> parameter.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle specified by the <paramref name="SessionHandle"/> parameter is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The <paramref name="Identity"/>, <paramref name="PropertyBuffer"/>, or <paramref name="PropertyBufferSize"/> arguments cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="UnitId"/>, <paramref name="Identity"/>, or <paramref name="SubFactor"/> arguments are incorrect.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INVALID_PROPERTY_TYPE"/></term>
        /// <description>The value of the <paramref name="PropertyType"/> argument is incorrect.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INVALID_PROPERTY_ID"/></term>
        /// <description>The value of the <paramref name="PropertyId"/> argument is incorrect.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The caller attempted to query a property that resides inside of a locked region.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_UNSUPPORTED_PROPERTY"/></term>
        /// <description>The object being queried does not support the specified property.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioGetProperty([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                              [In] WINBIO_PROPERTY_TYPE PropertyType,
                                                              [In] WINBIO_PROPERTY_ID PropertyId,
                                                              [In] WINBIO_UNIT_ID UnitId,
                                                              [In] WINBIO_IDENTITY* Identity,
                                                              [In] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
                                                              [Out] out PVOID PropertyBuffer,
                                                              [Out] out SIZE_T PropertyBufferSize);

        /// <summary>
        /// Retrieves the ID number of a biometric unit selected interactively by a user.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="UnitId">A pointer to a ULONG value that specifies the biometric unit.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified by the UnitId parameter cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioLocateSensor([In]  WINBIO_SESSION_HANDLE SessionHandle,
                                                        [Out] out WINBIO_UNIT_ID UnitId);

        /// <summary>
        /// <para>Asynchronously retrieves the ID number of the biometric unit selected interactively by a user. The function returns immediately to the caller, processes on a separate thread, and reports the selected biometric unit by calling an application-defined callback function.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioLocateSensor"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session.</param>
        /// <param name="LocateCallback">Address of a callback function that will be called by the WinBioLocateSensorWithCallback function when sensor location succeeds or fails. You must create the callback.</param>
        /// <param name="LocateCallbackContext">Address of an application-defined data structure that is passed to the callback function in its LocateCallbackContext parameter. This structure can contain any data that the custom callback function is designed to handle.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The address specified by the Locate</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioLocateSensorWithCallback([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                    [In] WINBIO_LOCATE_SENSOR_CALLBACK LocateCallback,
                                                                    [In] PVOID LocateCallbackContext);

        /// <summary>
        /// Locks a biometric unit for exclusive use by a single session.
        /// </summary>
        /// <param name="SessionHandle">A WINBIO_SESSION_HANDLE value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="UnitId">A WINBIO_UNIT_ID value that specifies the biometric unit to be locked.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="UnitId"/> parameter cannot contain zero.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit cannot be locked because the specified session already has another unit locked.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioLockUnit([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                    [In] WINBIO_UNIT_ID UnitId);

        /// <summary>
        /// Connects to a biometric service provider and one or more biometric units.
        /// </summary>
        /// <param name="Factor">A bitmask of <para>WINBIO_BIOMETRIC_TYPE</para> flags that specifies the biometric unit types to be enumerated. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.</param>
        /// <param name="PoolType">
        /// <para>A ULONG value that specifies the type of the biometric units that will be used in the session. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_POOL_SYSTEM"/></term>
        /// <description>The session connects to a shared collection of biometric units managed by the service provider.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_POOL_PRIVATE"/></term>
        /// <description>The session connects to a collection of biometric units that are managed by the caller.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="Flags">
        /// <para>A ULONG value that specifies biometric unit configuration and access characteristics for the new session. Configuration flags specify the general configuration of units in the session. Access flags specify how the application will use the biometric units. You must specify one configuration flag but you can combine that flag with any access flag.</para>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_DEFAULT"/></term>
        /// <description><para>Group: configuration</para><para>The biometric units operate in the manner specified during installation. You must use this value when the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>.</para></description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_BASIC"/></term>
        /// <description><para>Group: configuration</para><para>The biometric units operate only as basic capture devices. All processing, matching, and storage operations is performed by software plug-ins.</para></description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_ADVANCED"/></term>
        /// <description><para>Group: configuration</para><para>The biometric units use internal processing and storage capabilities.</para></description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_RAW"/></term>
        /// <description><para>Group: access</para><para>The client application captures raw biometric data using <see cref="WinBioCaptureSample"/>.</para></description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_FLAG_MAINTENANCE"/></term>
        /// <description><para>Group: access</para><para>The client performs vendor-defined control operations on a biometric unit by calling <see cref="WinBioControlUnitPrivileged"/>.</para></description>
        /// </item>
        /// </param>
        /// <param name="UnitArray">Pointer to an array of biometric unit identifiers to be included in the session. You can call <see cref="WinBioEnumBiometricUnits"/> to enumerate the biometric units. Set this value to NULL if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>.</param>
        /// <param name="UnitCount">A value that specifies the number of elements in the array pointed to by the <paramref name="UnitArray"/> parameter. Set this value to zero if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>.</param>
        /// <param name="DatabaseId">
        /// <para>A value that specifies the database(s) to be used by the session. If the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_PRIVATE"/>, you must specify the <see cref="SafeNativeMethods.GUID"/> of an installed database. If the <paramref name="PoolType"/> parameter is not <see cref="WINBIO_POOL_PRIVATE"/>, you can specify one of the following common values.</para>
        /// <item>
        /// <term><see cref="WINBIO_DB_DEFAULT"/></term>
        /// <description>Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration. You must specify this value if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_SYSTEM"/>. You cannot use this value if the <paramref name="PoolType"/> parameter is <see cref="WINBIO_POOL_PRIVATE"/></description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_DB_BOOTSTRAP"/></term>
        /// <description>You can specify this value to be used for scenarios prior to starting Windows. Typically, the database is part of the sensor chip or is part of the BIOS and can only be used for template enrollment and deletion.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_DB_ONCHIP"/></term>
        /// <description>The database is on the sensor chip and is available for enrollment and matching.</description>
        /// </item>
        /// </param>
        /// <param name="SessionHandle">Pointer to the new session handle. If the function does not succeed, the handle is set to zero.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>One or more arguments have incorrect values or are incompatible with other arguments.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The session handle pointer in the <paramref name="SessionHandle"/> parameter cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The <paramref name="Flags"/> parameter contains the <see cref="WINBIO_FLAG_RAW"/> or the <see cref="WINBIO_FLAG_MAINTENANCE"/> flag and the caller has not been granted either access permission.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INVALID_UNIT"/></term>
        /// <description>One or more of the biometric unit numbers specified in the <paramref name="UnitArray"/> parameter is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_NOT_ACTIVE_CONSOLE"/></term>
        /// <description>The client application is running on a remote desktop client and is attempting to open a system pool session.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_SENSOR_UNAVAILABLE"/></term>
        /// <description>The <paramref name="PoolType"/> parameter is set to <see cref="WINBIO_POOL_PRIVATE"/> and one or more of the requested sensors in that pool is not available.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the Windows Biometric Framework API.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioOpenSession([In] WINBIO_BIOMETRIC_TYPE Factor,
                                                              [In]  WINBIO_POOL_TYPE PoolType,
                                                              [In]  WINBIO_SESSION_FLAGS Flags,
                                                              [In]  WINBIO_UNIT_ID[] UnitArray,
                                                              [In]  SIZE_T UnitCount,
                                                              [In]  Guid* DatabaseId,
                                                              [Out] out WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// The <see cref="WinBioLogonIdentifiedUser"/> function causes a fast user switch to the account associated with the last successful identification operation performed by the biometric session.
        /// </summary>
        /// <param name="SessionHandle"></param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to switch users or the biometric session is out of date.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="S_FALSE"/></term>
        /// <description>The user identified by the <paramref name="SessionHandle"/> parameter is the same as the current user.</description>
        /// </item>
        /// <item>
        /// <term><see cref="SEC_E_LOGON_DENIED"/></term>
        /// <description>The user could not be logged on.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_CRED_PROV_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the credential provider.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_FAST_USER_SWITCH_DISABLED"/></term>
        /// <description>Fast user switching is not enabled.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_SAS_ENABLED"/></term>
        /// <description>Fast user switching cannot be performed because secure logon (CTRL+ALT+DELETE) is currently enabled.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioLogonIdentifiedUser([In] WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// The <see cref="WinBioRegisterEventMonitor"/> function Registers a callback function to receive event notifications from the service provider associated with an open session.
        /// </summary>
        /// <param name="SessionHandle">A WINBIO_SESSION_HANDLE value that identifies the open biometric session. Open the session handle by calling <see cref="WinBioOpenSession"/>.</param>
        /// <param name="EventMask">
        /// <para>A value that specifies the types of events to monitor. Only the fingerprint provider is currently supported. You must specify one of the following flags.</para>
        /// <para><see cref="WINBIO_EVENT_FP_UNCLAIMED"/> (The sensor detected a finger swipe that was not requested by the application, or the requesting application does not have window focus. The Windows Biometric Framework calls into your callback function to indicate that a finger swipe has occurred but does not try to identify the fingerprint.)</para>
        /// <para><see cref="WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY"/> (The sensor detected a finger swipe that was not requested by the application, or the requesting application does not have window focus. The Windows Biometric Framework attempts to identify the fingerprint and passes the result of that process to your callback function.)</para>
        /// </param>
        /// <param name="EventCallback">Address of a callback function that receives the event notifications sent by the Windows Biometric Framework. You must define this function.</param>
        /// <param name="EventCallbackContext">An optional application-defined value that is returned in the pvContext parameter of the callback function. This value can contain any data that the custom callback function is designed to handle.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The address of the callback function specified by the EventCallback parameter cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="EventMask"/> parameter cannot be zero and you cannot specify both <see cref="WINBIO_EVENT_FP_UNCLAIMED"/> and <see cref="WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY"/> at the same time.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_EVENT_MONITOR_ACTIVE"/></term>
        /// <description>An active event monitor has already been registered.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_INVALID_OPERATION"/></term>
        /// <description>The service provider does not support event notification.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioRegisterEventMonitor([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                [In] WINBIO_EVENT_TYPE EventMask,
                                                                [In] WINBIO_EVENT_CALLBACK EventCallback,
                                                                [In] PVOID EventCallbackContext);

        /// <summary>
        /// Releases window focus.
        /// </summary>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The calling process must be running under the Local System account.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioReleaseFocus();

        /// <summary>
        /// Removes all credentials from the store.
        /// </summary>
        /// <returns>If the function succeeds, it returns S_OK. If the function fails, it returns an HRESULT value that indicates the error. For a list of common error codes, see Common HRESULT Values.</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioRemoveAllCredentials();

        /// <summary>
        /// Removes all user credentials for the current domain from the store.
        /// </summary>
        /// <returns>If the function succeeds, it returns S_OK. If the function fails, it returns an HRESULT value that indicates the error. For a list of common error codes, see Common HRESULT Values.</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioRemoveAllDomainCredentials();

        /// <summary>
        /// Deletes a biometric logon credential for a specified user. Starting with Windows 10, build 1607, this function is available to use with a mobile image.
        /// </summary>
        /// <param name="Identity">A <see cref="WINBIO_IDENTITY"/> structure that contains the SID of the user account for which the logon credential will be removed.</param>
        /// <param name="Type">
        /// <para>A <see cref="WINBIO_CREDENTIAL_TYPE"/> value that specifies the credential type. This can be one of the following values:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_CREDENTIAL_PASSWORD"/></term>
        /// <description>The password-based credential will be deleted.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_CREDENTIAL_ALL"/></term>
        /// <description>All logon credentials for the user will be deleted.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to delete the credential.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_CRED_PROV_NO_CREDENTIAL"/></term>
        /// <description>The specified identity does not exist or does not have any related records in the credential store.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioRemoveCredential([In] WINBIO_IDENTITY Identity,
                                                            [In] WINBIO_CREDENTIAL_TYPE Type);

        /// <summary>
        /// Saves a biometric logon credential for the current user.
        /// </summary>
        /// <param name="Type">A <see cref="WINBIO_CREDENTIAL_TYPE"/> value that specifies the credential type. Currently, this can be WINBIO_CREDENTIAL_PASSWORD.</param>
        /// <param name="Credential">A pointer to a variable length array of bytes that contains the credential. The format depends on the <paramref name="Type"/> and <paramref name="Format"/> parameters.</param>
        /// <param name="CredentialSize">Size, in bytes, of the value specified by the <paramref name="Credential"/> parameter.</param>
        /// <param name="Format">
        /// <para>A <see cref="WINBIO_CREDENTIAL_FORMAT"/> enumeration value that specifies the format of the credential. If the Type parameter is <see cref="WINBIO_CREDENTIAL_TYPE.WINBIO_CREDENTIAL_PASSWORD"/>, this can be one of the following:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="WINBIO_PASSWORD_GENERIC"/></term>
        /// <description>The credential is a plaintext NULL-terminated Unicode string.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_PASSWORD_PACKED"/></term>
        /// <description>The credential was wrapped by using the CredProtect function and packed by using the CredPackAuthenticationBuffer function. This is recommended.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_PASSWORD_PROTECTED"/></term>
        /// <description>The password credential was wrapped with CredProtect.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_ACCESSDENIED"/></term>
        /// <description>The caller does not have permission to set the credential.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_UNKNOWN_ID"/></term>
        /// <description>The user has not enrolled a biometric sample.</description>
        /// </item>
        /// <item>
        /// <term><see cref="SEC_E_LOGON_DENIED"/></term>
        /// <description>The credential was not valid for the current user.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_CRED_PROV_DISABLED"/></term>
        /// <description>Current administrative policy prohibits use of the credential provider.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioSetCredential([In] WINBIO_CREDENTIAL_TYPE Type,
                                                         [In] PUCHAR Credential,
                                                         [In] SIZE_T CredentialSize,
                                                         [In] WINBIO_CREDENTIAL_FORMAT Format);

        /// <summary>
        /// Releases the session lock on the specified biometric unit.
        /// </summary>
        /// <param name="SessionHandle">A WINBIO_SESSION_HANDLE value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="UnitId">A WINBIO_UNIT_ID value that specifies the biometric unit to unlock.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="UnitId"/> parameter cannot contain zero.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_LOCK_VIOLATION"/></term>
        /// <description>The biometric unit specified by the UnitId parameter is not currently locked by the session.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioUnlockUnit([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                      [In] WINBIO_UNIT_ID UnitId);

        /// <summary>
        /// The <see cref="WinBioUnregisterEventMonitor"/> function cancels event notifications from the service provider associated with an open biometric session.
        /// </summary>
        /// <param name="SessionHandle">A WINBIO_SESSION_HANDLE value that identifies the open biometric session. Open the session handle by calling <see cref="WinBioOpenSession"/>.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioUnregisterEventMonitor([In] WINBIO_SESSION_HANDLE SessionHandle);

        /// <summary>
        /// Captures a biometric sample and determines whether the sample corresponds to the specified user identity.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <param name="Identity">Pointer to a <see cref="WINBIO_IDENTITY"/> structure that contains the GUID or SID of the user providing the biometric sample.</param>
        /// <param name="SubFactor">
        /// <para>A <see cref="WINBIO_BIOMETRIC_SUBTYPE"/> value that specifies the sub-factor associated with the biometric sample. The Windows Biometric Framework (WBF) currently supports only fingerprint capture and can use the following constants to represent sub-type information.</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_THUMB"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_INDEX_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_RING_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_LITTLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_THUMB"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_INDEX_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_RING_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_LITTLE_FINGER"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_RH_FOUR_FINGERS"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_ANSI_381_POS_LH_FOUR_FINGERS"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_SUBTYPE_ANY"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="UnitId">A pointer to a <see cref="WINBIO_UNIT_ID"/> value that specifies the biometric unit that performed the verification.</param>
        /// <param name="Match">Pointer to a Boolean value that specifies whether the captured sample matched the user identity specified by the <paramref name="Identity"/> parameter.</param>
        /// <param name="RejectDetail">
        /// <para>A pointer to a ULONG value that contains additional information about the failure to capture a biometric sample. If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:</para>
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_HIGH"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_LEFT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_RIGHT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_FAST"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SLOW"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_POOR_QUALITY"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SKEWED"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_TOO_SHORT"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WINBIO_FP_MERGE_FAILURE"/></description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="SubFactor"/> argument is incorrect.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified by the <paramref name="UnitId"/>, <paramref name="Identity"/>, <paramref name="SubFactor"/>, or <paramref name="RejectDetail"/> parameters cannot be NULL.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_BAD_CAPTURE"/></term>
        /// <description>The biometric sample could not be captured. Use the <paramref name="RejectDetail"/> value for more information.</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_ENROLLMENT_IN_PROGRESS"/></term>
        /// <description>The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction (system pool only).</description>
        /// </item>
        /// <item>
        /// <term><see cref="WINBIO_E_NO_MATCH"/></term>
        /// <description>The biometric sample does not correspond to the specified <paramref name="Identity"/> and <paramref name="SubFactor"/> combination.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioVerify([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                         [In] WINBIO_IDENTITY* Identity,
                                                         [In] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
                                                         [Out] out WINBIO_UNIT_ID UnitId,
                                                         [Out] out BOOLEAN Match,
                                                         [Out] out WINBIO_REJECT_DETAIL RejectDetail);

        /// <summary>
        /// <para>Asynchronously captures a biometric sample and determines whether the sample corresponds to the specified user identity. The function returns immediately to the caller, performs capture and verification on a separate thread, and calls into an application-defined callback function to update operation status.</para>
        /// <para>Important  We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Implement a <see cref="PWINBIO_ASYNC_COMPLETION_CALLBACK"/> function to receive notice when the operation completes.</description>
        /// </item>
        /// <item>
        /// <description>Call the <see cref="WinBioAsyncOpenSession"/> function. Pass the address of your callback in the CallbackRoutine parameter. Pass <see cref="WINBIO_ASYNC_NOTIFY_CALLBACK"/> in the NotificationMethod parameter. Retrieve an asynchronous session handle.</description>
        /// </item>
        /// <item>
        /// <description>Use the asynchronous session handle to call <see cref="WinBioVerify"/>. When the operation finishes, the Windows Biometric Framework will allocate and initialize a <see cref="WINBIO_ASYNC_RESULT"/> structure with the results and invoke your callback with a pointer to the results structure.</description>
        /// </item>
        /// <item>
        /// <description>Call <see cref="WinBioFree"/> from your callback implementation to release the <see cref="WINBIO_ASYNC_RESULT"/> structure after you have finished using it.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session.</param>
        /// <param name="Identity">Pointer to a <see cref="WINBIO_IDENTITY"/> structure that contains the GUID or SID of the user providing the biometric sample.</param>
        /// <param name="SubFactor">A <see cref="WINBIO_BIOMETRIC_SUBTYPE"/> value that specifies the sub-factor associated with the biometric sample. See the Remarks section for more details.</param>
        /// <param name="VerifyCallback">Address of a callback function that will be called by the <see cref="WinBioVerifyWithCallback"/> function when verification succeeds or fails. You must create the callback.</param>
        /// <param name="VerifyCallbackContext">An optional application-defined structure that is returned in the <paramref name="VerifyCallbackContext"/> parameter of the callback function. This structure can contain any data that the custom callback function is designed to handle.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_INVALIDARG"/></term>
        /// <description>The <paramref name="SubFactor"/> argument is incorrect.</description>
        /// </item>
        /// <item>
        /// <term><see cref="E_POINTER"/></term>
        /// <description>The pointer specified by the Identity and <paramref name="VerifyCallback"/> parameters cannot be NULL.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe HRESULT WinBioVerifyWithCallback([In] WINBIO_SESSION_HANDLE SessionHandle,
                                                                     [In] WINBIO_IDENTITY* Identity,
                                                                     [In] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
                                                                     [In] WINBIO_VERIFY_CALLBACK VerifyCallback,
                                                                     [In] PVOID VerifyCallbackContext);

        /// <summary>
        /// Blocks caller execution until all pending biometric operations for a session have been completed or canceled.
        /// </summary>
        /// <param name="SessionHandle">A <see cref="WINBIO_SESSION_HANDLE"/> value that identifies an open biometric session. Open a synchronous session handle by calling <see cref="WinBioOpenSession"/>. Open an asynchronous session handle by calling <see cref="WinBioAsyncOpenSession"/>.</param>
        /// <returns>
        /// <para>If the function succeeds, it returns <see cref="S_OK"/>. If the function fails, it returns an HRESULT value that indicates the error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Return code</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="E_HANDLE"/></term>
        /// <description>The session handle is not valid.</description>
        /// </item>
        /// </list>
        /// </returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, CallingConvention = CallingConvention.Winapi)]
        public static extern HRESULT WinBioWait([In] WINBIO_SESSION_HANDLE SessionHandle);




        #endregion

        #region Structs

        /// <summary>
        /// <para>GUIDs identify objects such as interfaces, manager entry-point vectors (EPVs), and class objects. A GUID is a 128-bit value consisting of one group of 8 hexadecimal digits, followed by three groups of 4 hexadecimal digits each, followed by one group of 12 hexadecimal digits. The following example GUID shows the groupings of hexadecimal digits in a GUID: 6B29FC40-CA47-1067-B31D-00DD010662DA</para>
        /// <para>The <see cref="GUID"/> structure stores a GUID.</para>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct GUID
        {

            /// <summary>
            /// Initializes a new instance of the Guid structure by using the specified integers and bytes.
            /// </summary>
            /// <param name="a">The first 4 bytes of the GUID.</param>
            /// <param name="b">The next 2 bytes of the GUID.</param>
            /// <param name="c">The next 2 bytes of the GUID.</param>
            /// <param name="d">The next byte of the GUID.</param>
            /// <param name="e">The next byte of the GUID.</param>
            /// <param name="f">The next byte of the GUID.</param>
            /// <param name="g">The next byte of the GUID.</param>
            /// <param name="h">The next byte of the GUID.</param>
            /// <param name="i">The next byte of the GUID.</param>
            /// <param name="j">The next byte of the GUID.</param>
            /// <param name="k">The next byte of the GUID.</param>
            public GUID(DWORD a, WORD b, WORD c, BYTE d, BYTE e, BYTE f, BYTE g, BYTE h, BYTE i, BYTE j, BYTE k)
            {
                this.Data1 = a;
                this.Data2 = b;
                this.Data3 = c;
                fixed (byte* p = this.Data4)
                {
                    p[0] = d;
                    p[1] = e;
                    p[2] = f;
                    p[3] = g;
                    p[4] = h;
                    p[5] = i;
                    p[6] = j;
                    p[7] = k;
                }
            }

            /// <summary>
            /// Specifies the first 8 hexadecimal digits of the GUID.
            /// </summary>
            public DWORD Data1;

            /// <summary>
            /// Specifies the first group of 4 hexadecimal digits.
            /// </summary>
            public WORD Data2;

            /// <summary>
            /// Specifies the second group of 4 hexadecimal digits.
            /// </summary>
            public WORD Data3;

            /// <summary>
            /// Array of 8 bytes. The first 2 bytes contain the third group of 4 hexadecimal digits. The remaining 6 bytes contain the final 12 hexadecimal digits.
            /// </summary>
            public fixed BYTE Data4[8];

        }

        /// <summary>
        /// Represents a 64-bit signed integer value.
        /// </summary>
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public struct LARGE_INTEGER
        {

            /// <summary>
            /// An unsigned 64-bit integer.
            /// </summary>
            [FieldOffset(0)]
            public Int64 QuadPart;

            /// <summary>
            /// The low-order 32 bits.
            /// </summary>
            [FieldOffset(0)]
            public UInt32 LowPart;

            /// <summary>
            /// The high-order 32 bits.
            /// </summary>
            [FieldOffset(4)]
            public Int32 HighPart;

        }

        #region WINBIO_ASYNC_RESULT structure

        /// <summary>
        /// The <see cref="WINBIO_ASYNC_RESULT"/> structure contains the results of an asynchronous operation.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT
        {

            /// <summary>
            /// Handle of an asynchronous session started by calling the <see cref="WinBioAsyncOpenSession"/> function or the <see cref="WinBioAsyncOpenFramework"/> function.
            /// </summary>
            public WINBIO_SESSION_HANDLE SessionHandle;

            /// <summary>
            /// Type of the asynchronous operation. For more information, see WINBIO_OPERATION_TYPE Constants.
            /// </summary>
            public WINBIO_OPERATION_TYPE Operation;

            /// <summary>
            /// Sequence number of the asynchronous operation. The integers are assigned sequentially for each operation in a biometric session, starting at one (1). For any session, the open operation is always assigned the first sequence number and the close operation is assigned the last sequence number. If your application queues multiple operations, you can use sequence numbers to perform error handling. For example, you can ignore operation results until a specific sequence number is sent to the application.
            /// </summary>
            public ULONGLONG SequenceNumber;

            /// <summary>
            /// System date and time at which the biometric operation began. For more information, see the <see cref="GetSystemTimeAsFileTime"/> function.
            /// </summary>
            public LONGLONG TimeStamp;

            /// <summary>
            /// Error code returned by the operation.
            /// </summary>
            public HRESULT ApiStatus;

            /// <summary>
            /// Biometric unit ID number.
            /// </summary>
            public WINBIO_UNIT_ID UnitId;

            /// <summary>
            /// Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it determine what actions to perform upon receipt of the completion notice or to maintain additional information about the requested operation.
            /// </summary>
            public PVOID UserData;

            /// <summary>
            /// Union that encloses nested structures that contain additional information about the success or failure of asynchronous operations begun by the client application.
            /// </summary>
            public WINBIO_ASYNC_RESULT_VERIFY Verify;

        }

        /// <summary>
        /// Union that encloses nested structures that contain additional information about the success or failure of asynchronous operations begun by the client application.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct WINBIO_ASYNC_RESULT_PARAMETERS
        {
            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioVerify"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_VERIFY Verify;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioIdentify"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_IDENTITY Identify;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnrollBegin"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENROLLBEGIN EnrollBegin;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnrollCapture"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENROLLCAPTURE EnrollCapture;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnrollCommit"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENROLLCOMMIT EnrollCommit;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnumEnrollments"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENUMENROLLMENTS EnumEnrollments;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioCaptureSample"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_CAPTURESAMPLE CaptureSample;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioDeleteTemplate"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_DELETESAMPLE DeleteTemplate;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioGetProperty"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_GETPROPERTY GetProperty;

            /// <summary>
            /// Reserved.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_SETPROPERTY SetProperty;

            /// <summary>
            /// Contains status information about the event that was raised.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_GETEVENT GetEvent;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioControlUnit"/> or <see cref="WinBioControlUnitPrivileged"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_CONTROLUNIT ControlUnit;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnumServiceProviders"/> or <see cref="WinBioAsyncEnumServiceProviders"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENUMSERVICEPROVIDERS EnumServiceProviders;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnumBiometricUnits"/> or <see cref="WinBioAsyncEnumBiometricUnits"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENUMBIOMETRICUNITS EnumBiometricUnits;

            /// <summary>
            /// Contains the results of an asynchronous call to <see cref="WinBioEnumDatabases"/> or <see cref="WinBioAsyncEnumDatabases"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_ASYNC_RESULT_ENUMDATABASES EnumDatabases;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioVerify"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_VERIFY
        {

            /// <summary>
            /// Specifies whether the captured sample matched the user identity.
            /// </summary>
            public BOOLEAN Match;

            /// <summary>
            /// Additional information about verification failure. For more information, see Remarks.
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioIdentify"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_IDENTITY
        {

            /// <summary>
            /// GUID or SID of the user providing the biometric sample.
            /// </summary>
            public WINBIO_IDENTITY Identity;

            /// <summary>
            /// Sub-factor associated with the biometric sample. For more information, see Remarks.
            /// </summary>
            public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

            /// <summary>
            /// Additional information about the failure, if any, to capture and identify a biometric sample. For more information, see Remarks.
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnrollBegin"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENROLLBEGIN
        {

            /// <summary>
            /// Additional information about the enrollment. For more information, see Remarks.
            /// </summary>
            public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnrollCapture"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENROLLCAPTURE
        {
            /// <summary>
            /// Additional information about the failure to capture a biometric sample. For more information, see Remarks.
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnrollCommit"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENROLLCOMMIT
        {

            /// <summary>
            /// GUID or SID of the template to be saved.
            /// </summary>
            public WINBIO_IDENTITY Identity;

            /// <summary>
            /// Specifies whether the template being added to the database is new.
            /// </summary>
            public BOOLEAN IsNewTemplate;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnumEnrollments"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENUMENROLLMENTS
        {

            /// <summary>
            /// GUID or SID of the template from which the sub-factors were retrieved.
            /// </summary>
            public WINBIO_IDENTITY Identity;

            /// <summary>
            /// Number of elements in the array pointed to by the <see cref="SubFactorArray"/> member.
            /// </summary>
            public SIZE_T SubFactorCount;

            /// <summary>
            /// Pointer to an array of sub-factors. For more information, see Remarks.
            /// </summary>
            public IntPtr SubFactorArray;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioCaptureSample"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_CAPTURESAMPLE
        {

            /// <summary>
            /// Pointer to a <see cref="WINBIO_BIR"/> structure that contains the sample.
            /// </summary>
            public IntPtr Sample;

            /// <summary>
            /// Size, in bytes, of the <see cref="WINBIO_BIR"/> structure returned in the Sample member.
            /// </summary>
            public SIZE_T SampleSize;

            /// <summary>
            /// Additional information about the failure to capture a biometric sample. For more information, see Remarks.
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioDeleteTemplate"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_DELETESAMPLE
        {

            /// <summary>
            /// GUID or SID of the template that was deleted.
            /// </summary>
            public WINBIO_IDENTITY Identity;

            /// <summary>
            /// Additional information about the template.
            /// </summary>
            public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioGetProperty"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_GETPROPERTY
        {

            /// <summary>
            /// Source of the property information. Currently this will be <see cref="WINBIO_PROPERTY_TYPE_UNIT"/>.
            /// </summary>
            public WINBIO_PROPERTY_TYPE PropertyType;

            /// <summary>
            /// The property that was queried. Currently this will be <see cref="WINBIO_PROPERTY_SAMPLE_HINT"/>.
            /// </summary>
            public WINBIO_PROPERTY_ID PropertyId;

            /// <summary>
            /// This is a reserved value and will be NULL.
            /// </summary>
            public WINBIO_IDENTITY Identity;

            /// <summary>
            /// This is reserved and will be WINBIO_SUBTYPE_NO_INFORMATION.
            /// </summary>
            public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

            /// <summary>
            /// Size, in bytes, of the property value pointed to by the <see cref="PropertyBuffer"/> member.
            /// </summary>
            public SIZE_T PropertyBufferSize;

            /// <summary>
            /// Pointer to the property value.
            /// </summary>
            public PVOID PropertyBuffer;

        }

        /// <summary>
        /// Reserved.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_SETPROPERTY
        {

            /// <summary>
            /// Reserved.
            /// </summary>
            public ULONG None;

        }

        /// <summary>
        /// Contains status information about the event that was raised.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_GETEVENT
        {

            /// <summary>
            /// Contains event information.
            /// </summary>
            public WINBIO_EVENT Event;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioControlUnit"/> or <see cref="WinBioControlUnitPrivileged"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_CONTROLUNIT
        {

            /// <summary>
            /// The component within the biometric unit that performed the operation.
            /// </summary>
            public WINBIO_COMPONENT Component;

            /// <summary>
            /// Vendor-defined code recognized by the biometric unit specified by the UnitId parameter of the <see cref="WinBioControlUnit"/> or <see cref="WinBioControlUnitPrivileged"/> function and the adapter specified by the Component parameter.
            /// </summary>
            public ULONG ControlCode;

            /// <summary>
            /// Vendor-defined status code that specifies the outcome of the control operation.
            /// </summary>
            public ULONG OperationStatus;

            /// <summary>
            /// Pointer to a buffer that contains the control information sent to the adapter by the component. The format and content of the buffer is vendor-defined.
            /// </summary>
            public PUCHAR SendBuffer;

            /// <summary>
            /// Size, in bytes, of the buffer specified by the <see cref="SendBuffer"/> member.
            /// </summary>
            public SIZE_T SendBufferSize;

            /// <summary>
            /// Pointer to a buffer that receives information sent by the adapter specified by the <see cref="Component"/> member. The format and content of the buffer is vendor-defined.
            /// </summary>
            public PUCHAR ReceiveBuffer;

            /// <summary>
            /// Size, in bytes, of the buffer specified by the <see cref="ReceiveBuffer"/> member.
            /// </summary>
            public SIZE_T ReceiveBufferSize;

            /// <summary>
            /// Size, in bytes, of the data written to the buffer specified by the <see cref="ReceiveBuffer"/> member.
            /// </summary>
            public SIZE_T ReceiveDataSize;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnumServiceProviders"/> or <see cref="WinBioAsyncEnumServiceProviders"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENUMSERVICEPROVIDERS
        {

            /// <summary>
            /// The number of structures pointed to by the <see cref="BspSchemaArray"/> member.
            /// </summary>
            public SIZE_T BspCount;

            /// <summary>
            /// Pointer to an array of <see cref="WINBIO_BSP_SCHEMA"/> structures that contain information about each of the available service providers.
            /// </summary>
            public IntPtr BspSchemaArray;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnumBiometricUnits"/> or <see cref="WinBioAsyncEnumBiometricUnits"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENUMBIOMETRICUNITS
        {

            /// <summary>
            /// Number of structures pointed to by the <see cref="UnitSchemaArray"/> member.
            /// </summary>
            public SIZE_T UnitCount;

            /// <summary>
            /// An array of <see cref="WINBIO_UNIT_SCHEMA"/> structures that contain information about each enumerated biometric unit.
            /// </summary>
            public IntPtr UnitSchemaArray;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to <see cref="WinBioEnumDatabases"/> or <see cref="WinBioAsyncEnumDatabases"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_ASYNC_RESULT_ENUMDATABASES
        {

            /// <summary>
            /// Number of structures pointed to by the <see cref="StorageSchemaArray"/> member.
            /// </summary>
            public SIZE_T StorageCount;

            /// <summary>
            /// Array of <see cref="WINBIO_STORAGE_SCHEMA"/> structures that contain information about each database.
            /// </summary>
            public IntPtr StorageSchemaArray;

        }

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BDB_ANSI_381_HEADER
        {

            public ULONG64 RecordLength;

            public ULONG FormatIdentifier;

            public ULONG VersionNumber;

            public WINBIO_REGISTERED_FORMAT ProductId;

            public USHORT CaptureDeviceId;

            public USHORT ImageAcquisitionLevel;

            public USHORT HorizontalScanResolution;

            public USHORT VerticalScanResolution;

            public USHORT HorizontalImageResolution;

            public USHORT VerticalImageResolution;

            public UCHAR ElementCount;

            public UCHAR ScaleUnits;

            public UCHAR PixelDepth;

            public UCHAR ImageCompressionAlg;

            public USHORT Reserved;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BDB_ANSI_381_RECORD
        {

            public ULONG BlockLength;

            public USHORT HorizontalLineLength;

            public USHORT VerticalLineLength;

            public WINBIO_BIOMETRIC_SUBTYPE Position;

            public UCHAR CountOfViews;

            public UCHAR ViewNumber;

            public UCHAR ImageQuality;

            public UCHAR ImpressionType;

            public UCHAR Reserved;

        }

        /// <summary>
        /// The <see cref="WINBIO_BIR"/> structure represents a biometric information record (BIR). The information record contains header, data, and signature blocks.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BIR
        {

            /// <summary>
            /// A <see cref="WINBIO_BIR_DATA"/> structure that contains the size, in bytes, and offset of the BIR header. The header contains information that describes the contents of the information record.
            /// </summary>
            public WINBIO_BIR_DATA HeaderBlock;

            /// <summary>
            /// A <see cref="WINBIO_BIR_DATA"/> structure that contains the size, in bytes, and offset of processed or unprocessed biometric information created by the Windows Biometric Framework (WBF).
            /// </summary>
            public WINBIO_BIR_DATA StandardDataBlock;

            /// <summary>
            /// A <see cref="WINBIO_BIR_DATA"/> structure that contains the size, in bytes, and offset of processed or unprocessed biometric information provided by vendor sensors and software.
            /// </summary>
            public WINBIO_BIR_DATA VendorDataBlock;

            /// <summary>
            /// An optional <see cref="WINBIO_BIR_DATA"/> structure that contains the size, in bytes, and offset of the digital signature message authentication code (MAC) that can be used to verify the integrity of the BIR. If present, the signature or MAC must cover the header and data blocks.
            /// </summary>
            public WINBIO_BIR_DATA SignatureBlock;

        }

        /// <summary>
        /// The <see cref="WINBIO_BIR_DATA"/> structure specifies the size, in bytes, and the offset of a block of biometric information. This structure is used by the <see cref="WINBIO_BIR"/> structure to specify where the various parts of a biometric information record are located.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BIR_DATA
        {

            /// <summary>
            /// Size, in bytes, of the biometric information.
            /// </summary>
            public ULONG Size;

            /// <summary>
            /// Offset, in bytes from the beginning of the <see cref="WINBIO_BIR"/> structure, of the biometric information.
            /// </summary>
            public ULONG Offset;

        }

        /// <summary>
        /// The <see cref="WINBIO_BIR_HEADER"/> structure contains the Common Biometric Exchange File Format (CBEFF) Patron Format A information that describes the rest of the BIR.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BIR_HEADER
        {

            /// <summary>
            /// A Patron Format A bitmask that indicates which CBEFF optional fields are present in the BIR. For more information about all members of <see cref="WINBIO_BIR_HEADER"/>, follow the link in the Remarks section to the NISTIR 6529-A Specification.
            /// </summary>
            public USHORT ValidFields;

            /// <summary>
            /// <para>A structure of type WINBIO_BIR_VERSION that specifies the CBEFF header version.</para>
            /// <para>Versions are represented as 8-bit values of the form: 0xNM, where N is the major version and M is the minor version.</para>
            /// <para><code>typedef UCHAR WINBIO_BIR_VERSION, *PWINBIO_BIR_VERSION;</code></para>
            /// </summary>
            public WINBIO_BIR_VERSION HeaderVersion;

            /// <summary>
            /// A structure of type WINBIO_BIR_VERSION that specifies PATRON_HEADER_VERSION.
            /// </summary>
            public WINBIO_BIR_VERSION PatronHeaderVersion;

            /// <summary>
            /// A structure of type <see cref="WINBIO_BIR_DATA_FLAGS"/> that specifies the level of processing expected for a data capture.
            /// </summary>
            public WINBIO_BIR_DATA_FLAGS DataFlags;

            /// <summary>
            /// A structure of type <see cref="WINBIO_BIOMETRIC_TYPE"/> that specifies the biometric type.
            /// </summary>
            public WINBIO_BIOMETRIC_TYPE Type;

            /// <summary>
            /// A structure of type WINBIO_BIOMETRIC_SENSOR_SUBTYPE that specifies the biometric subtype.
            /// </summary>
            public WINBIO_BIOMETRIC_SUBTYPE Subtype;

            /// <summary>
            /// A structure of type <see cref="WINBIO_BIR_PURPOSE"/> that specifies the intended use of the data.
            /// </summary>
            public WINBIO_BIR_PURPOSE Purpose;

            /// <summary>
            /// <para>A structure of type WINBIO_BIR_QUALITY that specifies the biometric data quality. Quality measurements are represented as signed integers in the range 0-100, except:</para>
            /// <para>-1 Quality measurements are supported by the BIR creator, but no value is set in the BIR.</para>
            /// <para>-2 Quality measurements are not supported by the BIR creator.</para>
            /// <para><code>typedef CHAR WINBIO_BIR_QUALITY, *PWINBIO_BIR_QUALITY;</code></para>
            /// </summary>
            public WINBIO_BIR_QUALITY DataQuality;

            /// <summary>
            /// Specifies the creation date and time of this BIR in UTC by using the format YYYYMMDDhhmmss.
            /// </summary>
            public LARGE_INTEGER CreationDate;

            /// <summary>
            /// Specifies the validity period of this BIR by using the format described in CreationDate.
            /// </summary>
            public WINBIO_BIR_HEADER_VERIFYPERIOD ValidityPeriod;

            /// <summary>
            /// A structure of type WINBIO_REGISTERED_FORMAT that specifies the data format of the StandardDataBlock for this <see cref="WINBIO_BIR"/>.
            /// </summary>
            public WINBIO_REGISTERED_FORMAT BiometricDataFormat;

            /// <summary>
            /// A structure of type WINBIO_REGISTERED_FORMAT that specifies the product identifier for the component that generated the StandardDataBlock for this <see cref="WINBIO_BIR"/>.
            /// </summary>
            public WINBIO_REGISTERED_FORMAT ProductId;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BIR_HEADER_VERIFYPERIOD
        {

            public LARGE_INTEGER BeginDate;

            public LARGE_INTEGER EndDate;

        }

        /// <summary>
        /// The IOCTL_BIOMETRIC_RESET and IOCTL_BIOMETRIC_UPDATE_FIRMWARE IOCTLs return the <see cref="WINBIO_BLANK_PAYLOAD"/> structure as output.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_BLANK_PAYLOAD
        {

            /// <summary>
            /// The total size of the payload. This includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// <para>The status detail of the I/O operation. This is where WINBIO error and information codes will be passed. The following table shows possible values.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Status value</term>
            /// <description>Description</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="S_OK"/></term>
            /// <description>The operation completed successfully.</description>
            /// </item>
            /// <item>
            /// <term><see cref="HRESULT_FROM_NT"/>(STATUS_IO_DEVICE_ERROR)</term>
            /// <description>The driver could not gather the necessary information from the device.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_DEVICE_BUSY"/></term>
            /// <description>The device is in the middle of a vendor-specific operation. This should only be returned when the device cannot be reset, and the vendor-specific operation cannot be canceled.</description>
            /// </item>
            /// </list>
            /// </summary>
            public HRESULT WinBioHresult;

        }

        /// <summary>
        /// The <see cref="WINBIO_BSP_SCHEMA"/> structure describes the capabilities of a biometric service provider. This structure is used by the <see cref="WinBioEnumServiceProviders"/> function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WINBIO_BSP_SCHEMA
        {

            /// <summary>
            /// The type of biometric measurement used by this device. Currently this must be <see cref="WINBIO_TYPE_FINGERPRINT"/>.
            /// </summary>
            public WINBIO_BIOMETRIC_TYPE BiometricFactor;

            /// <summary>
            /// A value that uniquely identifies this biometric service provider component.
            /// </summary>
            public WINBIO_UUID BspId;

            /// <summary>
            /// A NULL-terminated Unicode string that contains a description of the biometric service provider.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string Description;

            /// <summary>
            /// A NULL-terminated Unicode string that contains the name of the vendor supplying the biometric service provider.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string Vendor;

            /// <summary>
            /// A <see cref="WINBIO_VERSION"/> structure the contains the software version of the biometric service provider component.
            /// </summary>
            public WINBIO_VERSION Version;

        }

        /// <summary>
        /// The IOCTL_BIOMETRIC_CALIBRATE IOCTL returns the <see cref="WINBIO_CALIBRATION_INFO"/> structure as output.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_CALIBRATION_INFO
        {

            /// <summary>
            /// The total size of the payload. This includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// <para>The status detail of the I/O operation. This is where WINBIO error and information codes will be passed. The following table shows possible values.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Status value</term>
            /// <description>Description</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="S_OK"/></term>
            /// <description>The operation completed successfully.</description>
            /// </item>
            /// <item>
            /// <term><see cref="HRESULT_FROM_NT"/>(STATUS_IO_DEVICE_ERROR)</term>
            /// <description>The driver could not gather the necessary information from the device.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_DEVICE_BUSY"/></term>
            /// <description>The device is in the middle of a vendor-specific operation. This should only be returned when the device cannot be reset, and the vendor-specific operation cannot be canceled.</description>
            /// </item>
            /// </list>
            /// </summary>
            public HRESULT WinBioHresult;

            /// <summary>
            /// A structure of type <see cref="WINBIO_DATA"/> that contains calibration data specific to this sensor. This member is optional.
            /// </summary>
            public WINBIO_DATA CalibrationData;

        }

        /// <summary>
        /// The IOCTL_BIOMETRIC_CAPTURE_DATA IOCTL returns the <see cref="WINBIO_CAPTURE_DATA"/> structure as output.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_CAPTURE_DATA
        {

            /// <summary>
            /// The total size of the payload. This includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// <para>The status detail of the I/O operation. This is where WINBIO error and information codes will be passed. The following table shows possible values for this member.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Status value</term>
            /// <description>Description</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="S_OK"/></term>
            /// <description>The operation completed successfully.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_DATA_COLLECTION_IN_PROGRESS"/></term>
            /// <description>There is already a data collection IOCTL pending.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_UNSUPPORTED_DATA_FORMAT"/></term>
            /// <description>The format specified is not supported by this driver and device.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_UNSUPPORTED_DATA_TYPE"/></term>
            /// <description>The type of data requested is not supported by this driver and device.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_INVALID_DEVICE_STATE"/></term>
            /// <description>The device could not be put into biometric capture mode. This could be because the device is in another non-data collection mode.</description>
            /// </item>
            /// <item>
            /// <term><see cref="HRESULT_FROM_NT"/>(STATUS_IO_DEVICE_ERROR)</term>
            /// <description>The operation was not completed due to device error.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_DEVICE_BUSY"/></term>
            /// <description>The device is in the middle of a vendor-specific operation.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_CANCELED"/></term>
            /// <description>The operation was canceled either by the caller, or an IOCTL_BIOMETRIC_RESET request.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_E_UNSUPPORTED_PURPOSE"/></term>
            /// <description>The capture purpose specified is not supported by the driver.</description>
            /// </item>
            /// </list>
            /// </summary>
            public HRESULT WinBioHresult;

            /// <summary>
            /// The <see cref="WINBIO_SENSOR_STATUS"/> status of the sensor after the capture has occurred.
            /// </summary>
            public WINBIO_SENSOR_STATUS SensorStatus;

            /// <summary>
            /// If the sensor status was <see cref="WINBIO_SENSOR_REJECT"/>, this member contains a <see cref="WINBIO_REJECT_DETAIL"/> value.
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

            /// <summary>
            /// A structure of type <see cref="WINBIO_DATA"/> that contains data captured by the device, of the format specified. The Data array member of the <see cref="WINBIO_DATA"/> structure should contain a <see cref="WINBIO_BIR"/> structure.
            /// </summary>
            public WINBIO_DATA CaptureData;

        }

        /// <summary>
        /// The IOCTL_BIOMETRIC_CAPTURE_DATA IOCTL uses the <see cref="WINBIO_CAPTURE_PARAMETERS"/> structure as input.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_CAPTURE_PARAMETERS
        {

            /// <summary>
            /// The total size of the payload.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// Specifies a <see cref="WINBIO_BIR_PURPOSE"/> reason for the data collection. Some sensors will go into a different mode depending on the reason for the data capture.
            /// </summary>
            public WINBIO_BIR_PURPOSE Purpose;

            /// <summary>
            /// Specifies the <see cref="WINBIO_REGISTERED_FORMAT"/> format of the data to be returned.
            /// </summary>
            public WINBIO_REGISTERED_FORMAT Format;

            /// <summary>
            /// An optional WINBIO_UUID vendor GUID. This indicates the preferred format of the vendor-specific data in the BIR.
            /// </summary>
            public WINBIO_UUID VendorFormat;

            /// <summary>
            /// Specifies the <see cref="WINBIO_BIR_DATA_FLAGS"/> level of processing and other attributes for the data to be returned. If format owner and type are the Windows standard, this must be <see cref="WINBIO_DATA_FLAG_RAW"/>.
            /// </summary>
            public WINBIO_BIR_DATA_FLAGS Flags;

        }

        /// <summary>
        /// The <see cref="WINBIO_DATA"/> structure specifies data in IOCTL payloads.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_DATA
        {

            /// <summary>
            /// Specifies the size, in bytes, of the payload.
            /// </summary>
            public DWORD Size;

            /// <summary>
            /// Specifies an array that contains the payload. Frequently this member contains a structure of type <see cref="WINBIO_BIR"/>.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public IntPtr[] Data;

        }

        /// <summary>
        /// The IOCTL_BIOMETRIC_GET_SENSOR_STATUS IOCTL returns the <see cref="WINBIO_DIAGNOSTICS"/> structure as output.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_DIAGNOSTICS
        {

            /// <summary>
            /// The total size of the payload. This includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// <para>The status detail of the I/O operation. This is where WINBIO error and information codes will be passed. The following table shows possible values.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Status value</term>
            /// <description>Description</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="S_OK"/></term>
            /// <description>The operation completed successfully.</description>
            /// </item>
            /// <item>
            /// <term><see cref="HRESULT_FROM_NT"/>(STATUS_IO_DEVICE_ERROR)</term>
            /// <description>The driver could not gather the necessary information from the device.</description>
            /// </item>
            /// </list>
            /// </summary>
            public HRESULT WinBioHresult;

            /// <summary>
            /// A structure of type <see cref="WINBIO_SENSOR_STATUS"/> that contains the operating status of the biometric sensor.
            /// </summary>
            public WINBIO_SENSOR_STATUS SensorStatus;

            /// <summary>
            /// An optional <see cref="WINBIO_DATA"/> structure for vendor-specific additional information.
            /// </summary>
            public WINBIO_DATA VendorDiagnostics;

        }

        /// <summary>
        /// The <see cref="WINBIO_EVENT"/> structure contains status information sent to the callback routine when an event notice is raised.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_EVENT
        {

            /// <summary>
            /// <para>A value that specifies the types of events to monitor. Only the fingerprint provider is currently supported. You must specify one of the following flags.</para>
            /// <para><see cref="WINBIO_EVENT_FP_UNCLAIMED"/> (The sensor detected a finger swipe that was not requested by the application, or the requesting application does not have window focus. The Windows Biometric Framework calls into your callback function to indicate that a finger swipe has occurred but does not try to identify the fingerprint.)</para>
            /// <para><see cref="WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY"/> (The sensor detected a finger swipe that was not requested by the application, or the requesting application does not have window focus. The Windows Biometric Framework attempts to identify the fingerprint and passes the result of that process to your callback function.)</para>
            /// </summary>
            public WINBIO_EVENT_TYPE Type;

            public WINBIO_EVENT_PARAMETERS Parameters;

        }

        [StructLayout(LayoutKind.Explicit)]
        public struct WINBIO_EVENT_PARAMETERS
        {

            /// <summary>
            /// Structure returned for biometric sample capture.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_EVENT_UNCLAIMED Unclaimed;

            /// <summary>
            /// Structure returned for biometric capture and identification. Identification determines whether a sample can be associated with an existing biometric template.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_EVENT_UNCLAIMEDIDENTITY UnclaimedIdentify;

            /// <summary>
            /// Structure that identifies the success or failure of the operation being monitored.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_EVENT_UERROR Error;

        }

        /// <summary>
        /// Structure returned for biometric sample capture.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_EVENT_UNCLAIMED
        {

            /// <summary>
            /// The biometric unit that generated the sample.
            /// </summary>
            public WINBIO_UNIT_ID UnitId;

            /// <summary>
            /// <para>A ULONG value that contains additional information regarding failure to capture a biometric sample. If a capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:</para>
            /// <list type="bullet">
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_HIGH"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_LOW"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_LEFT"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_RIGHT"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_FAST"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_SLOW"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_POOR_QUALITY"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_SKEWED"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_SHORT"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_MERGE_FAILURE"/></description>
            /// </item>
            /// </list>
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

        }

        /// <summary>
        /// Structure returned for biometric capture and identification. Identification determines whether a sample can be associated with an existing biometric template.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_EVENT_UNCLAIMEDIDENTITY
        {

            /// <summary>
            /// The biometric unit that generated the sample.
            /// </summary>
            public WINBIO_UNIT_ID UnitId;

            /// <summary>
            /// A <see cref="WINBIO_IDENTITY"/> structure that contains the GUID or SID of the user providing the biometric sample.
            /// </summary>
            public WINBIO_IDENTITY Identity;

            /// <summary>
            /// <para>A WINBIO_BIOMETRIC_SUBTYPE value that specifies the sub-factor associated with a biometric sample. The Windows Biometric Framework (WBF) currently supports only fingerprint capture and uses the following constants to represent sub-type information.</para>
            /// <list type="bullet">
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_UNKNOWN"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_RH_THUMB"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_RH_INDEX_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_RH_RING_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_RH_LITTLE_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_LH_THUMB"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_LH_INDEX_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_LH_RING_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_LH_LITTLE_FINGER"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_RH_FOUR_FINGERS"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_LH_FOUR_FINGERS"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_ANSI_381_POS_TWO_THUMBS"/></description>
            /// </item>
            /// </list>
            /// <para>Important</para>
            /// <para>Do not attempt to validate the value supplied for the SubFactor value. The Windows Biometrics Service will validate the supplied value before passing it through to your implementation. If the value is <see cref="WINBIO_SUBTYPE_NO_INFORMATION"/> or <see cref="WINBIO_SUBTYPE_ANY"/>, then validate where appropriate.</para>
            /// </summary>
            public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

            /// <summary>
            /// <para>A ULONG value that contains additional information about the failure to capture a biometric sample. If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:</para>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_HIGH"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_LOW"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_LEFT"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_RIGHT"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_FAST"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_SLOW"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_POOR_QUALITY"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_SKEWED"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_TOO_SHORT"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_MERGE_FAILURE"/></description>
            /// </item>
            /// </list>
            /// </summary>
            public WINBIO_REJECT_DETAIL RejectDetail;

        }

        /// <summary>
        /// Structure that identifies the success or failure of the operation being monitored.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_EVENT_UERROR
        {

            /// <summary>
            /// HRESULT value that contains <see cref="S_OK"/> or an error code that resulted from computations performed by the Windows Biometric Framework.
            /// </summary>
            public HRESULT ErrorCode;

        }

        /// <summary>
        /// The <see cref="WINBIO_GET_INDICATOR"/> structure is the OUT payload for IOCTL_BIOMETRIC_GET_INDICATOR.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_GET_INDICATOR
        {

            /// <summary>
            /// Specifies the total size of the payload, which includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// Specifies an HRESULT that contains the status of the I/O operation. See IOCTL_BIOMETRIC_GET_INDICATOR for possible values.
            /// </summary>
            public HRESULT WinBioHresult;

            /// <summary>
            /// Specifies a structure of type <see cref="WINBIO_INDICATOR_STATUS"/>, which indicateswhether the indicator light is on or off.
            /// </summary>
            public WINBIO_INDICATOR_STATUS IndicatorStatus;

        }

        /// <summary>
        /// Contains the results of an asynchronous call to WinBioEnrollCapture.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_IDENTITY
        {

            /// <summary>
            /// <para>Specifies the format of the identity information contained in this structure. This can be one of the following values:</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <description>Meaning</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="WINBIO_ID_TYPE_NULL"/></term>
            /// <description>The template has no associated ID.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_ID_TYPE_WILDCARD"/></term>
            /// <description>The structure matches all template identities.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_ID_TYPE_GUID"/></term>
            /// <description>The structure contains a GUID associated with the template.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_ID_TYPE_SID"/></term>
            /// <description>The structure contains the account SID associated with the template.</description>
            /// </item>
            /// </list>
            /// </summary>
            public WINBIO_IDENTITY_TYPE Type;

            /// <summary>
            /// A union that can contain one of the following values:
            /// </summary>
            public WINBIO_IDENTITY_VALUE Value;

        }

        /// <summary>
        /// A structure that contains an account SID if the Type member is <see cref="WINBIO_ID_TYPE_SID"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct WINBIO_IDENTITY_ACCOUNTSID
        {

            /// <summary>
            /// The number of characters in the SID.
            /// </summary>
            public ULONG Size;

            /// <summary>
            /// An array of unsigned characters that contain the SID. The current maximum size of the array is 68 characters.
            /// </summary>
            public fixed byte Data[(int)SECURITY_MAX_SID_SIZE];

        }

        /// <summary>
        /// A union that can contain one of the following values:
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct WINBIO_IDENTITY_VALUE
        {

            /// <summary>
            /// Contains 1 if the Type member is <see cref="WINBIO_ID_TYPE_NULL"/>.
            /// </summary>
            [FieldOffset(0)]
            public ULONG Null;

            /// <summary>
            /// Contains 1 if the Type member is <see cref="WINBIO_ID_TYPE_WILDCARD"/>.
            /// </summary>
            [FieldOffset(0)]
            public ULONG Wildcard;

            /// <summary>
            /// Contains a 128-bit GUID value that identifies the template if the Type member is <see cref="WINBIO_ID_TYPE_GUID"/>.
            /// </summary>
            [FieldOffset(0)]
            public GUID TemplateGuid;

            /// <summary>
            /// A structure that contains an account SID if the Type member is <see cref="WINBIO_ID_TYPE_SID"/>.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_IDENTITY_ACCOUNTSID AccountSid;

        }

        /// <summary>
        /// The <see cref="WINBIO_REGISTERED_FORMAT"/> structure specifies a biometric data format.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_REGISTERED_FORMAT
        {

            /// <summary>
            /// Specifies format owner.
            /// </summary>
            public USHORT Owner;

            /// <summary>
            /// Specifies format type.
            /// </summary>
            public USHORT Type;

        }

        /// <summary>
        /// The IOCTL_BIOMETRIC_GET_ATTRIBUTES structure returns the <see cref="WINBIO_SENSOR_ATTRIBUTES"/> structure as output.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WINBIO_SENSOR_ATTRIBUTES
        {

            /// <summary>
            /// A DWORD value that indicates the total size of the payload, including the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// <para>An HRESULT value that indicates containing status detail of the I/O operation. The following table includes possible values.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Status value</term>
            /// <description>Description</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="S_OK"/></term>
            /// <description>The operation completed successfully.</description>
            /// </item>
            /// <item>
            /// <term><see cref="HRESULT_FROM_NT"/>(STATUS_IO_DEVICE_ERROR)</term>
            /// <description>The driver could not gather the necessary information from the device.</description>
            /// </item>
            /// </list>
            /// </summary>
            public HRESULT WinBioHresult;

            /// <summary>
            /// A structure of type <see cref="WINBIO_VERSION"/> that contains a WinBio WBDI version that is supported by the driver. To be compatible with the WinBio service, <see cref="WinBioVersion"/> must contain the same major version as the current major version of the WinBio service, in addition to a minor version that is less than or equal to the current minor version of the WinBio service.
            /// </summary>
            public WINBIO_VERSION WinBioVersion;

            /// <summary>
            /// A structure of type <see cref="WINBIO_BIOMETRIC_TYPE"/> that contains a bitmask with type(s) of biometric data that is collected by the sensor. In Windows 7, only <see cref="WINBIO_TYPE_FINGERPRINT"/> is supported.
            /// </summary>
            public WINBIO_BIOMETRIC_TYPE SensorType;

            /// <summary>
            /// A structure of type <see cref="WINBIO_BIOMETRIC_SENSOR_SUBTYPE"/> that contains additional information about the sensor. For example, this member could specify whether the sensor requires the user to simply touch the sensor or swipe a finger over the sensor.
            /// </summary>
            public WINBIO_BIOMETRIC_SENSOR_SUBTYPE SensorSubType;

            /// <summary>
            /// A structure of type <see cref="WINBIO_CAPABILITIES"/>, which indicates which capabilities are supported by the device.
            /// </summary>
            public WINBIO_CAPABILITIES Capabilities;

            /// <summary>
            /// A structure of type WINBIO_STRING that contains the name of the device manufacturer.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string ManufacturerName;

            /// <summary>
            /// A structure of type WINBIO_STRING that contains the name of the device model.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string ModelName;

            /// <summary>
            /// A structure of type WINBIO_STRING that contains the serial number of the device, if one exists.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string SerialNumber;

            /// <summary>
            /// A structure of type <see cref="WINBIO_VERSION"/> that contains the version of the firmware that is loaded on the device.
            /// </summary>
            public WINBIO_VERSION FirmwareVersion;

            /// <summary>
            /// The number of formats that are supported by the driver and device. There must be at least one, which is the Windows standard format.
            /// </summary>
            public DWORD SupportedFormatEntries;

            /// <summary>
            /// A structure of type <see cref="WINBIO_REGISTERED_FORMAT"/> that contains a list of the formats supported by the driver and device.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public WINBIO_REGISTERED_FORMAT[] SupportedFormat;

        }

        /// <summary>
        /// The <see cref="WINBIO_SET_INDICATOR"/> structure is the IN payload for IOCTL_BIOMETRIC_SET_INDICATOR.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_SET_INDICATOR
        {

            /// <summary>
            /// Specifies the total size of the payload, which includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// Specifies a structure of type <see cref="WINBIO_INDICATOR_STATUS"/> that indicates whether the indicator light should be set on or off.
            /// </summary>
            public WINBIO_INDICATOR_STATUS IndicatorStatus;

        }

        /// <summary>
        /// The <see cref="WINBIO_STORAGE_SCHEMA"/> structure describes the capabilities of a biometric storage adapter. This structure is used by the <see cref="WinBioEnumDatabases"/> function.
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 1064)]
        public struct WINBIO_STORAGE_SCHEMA
        {

            /// <summary>
            /// The type of biometric measurement saved in the database.
            /// </summary>
            [FieldOffset(0)]
            public WINBIO_BIOMETRIC_TYPE BiometricFactor;

            /// <summary>
            /// A GUID that identifies the database.
            /// </summary>
            [FieldOffset(4)]
            public WINBIO_UUID DatabaseId;

            /// <summary>
            /// A GUID that identifies the format of the templates in the database.
            /// </summary>
            [FieldOffset(20)]
            public WINBIO_UUID DataFormat;

            /// <summary>
            /// <para>Information about the characteristics of the database. This can be a bitwise OR of the following constants.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <description>Meaning</description>
            /// </listheader>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_FLAG_MASK"/></para><para>0xFFFF0000</para></term>
            /// <description>0xFFFF0000</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_FLAG_REMOTE"/></para><para>0x00020000</para></term>
            /// <description>0x00020000</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_FLAG_REMOVABLE"/></para><para>0x00010000</para></term>
            /// <description>0x00010000</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_TYPE_DBMS"/></para><para>0x00000002</para></term>
            /// <description>0x00000002</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_TYPE_FILE"/></para><para>0x00000001</para></term>
            /// <description>0x00000001</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_TYPE_MASK"/></para><para>0x0000FFFF</para></term>
            /// <description>0x0000FFFF</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_TYPE_ONCHIP"/></para><para>0x00000003</para></term>
            /// <description>0x00000003</description>
            /// </item>
            /// <item>
            /// <term><para><see cref="WINBIO_DATABASE_TYPE_SMARTCARD"/></para><para>0x00000004</para></term>
            /// <description>0x00000004</description>
            /// </item>
            /// </list>
            /// </summary>
            [FieldOffset(36)]
            public ULONG Attributes;

            /// <summary>
            /// The path and file name of the database if it resides on the computer disk.
            /// </summary>
            [FieldOffset(40)]
            public IntPtr FilePath;

            /// <summary>
            /// A string value that can be sent to a database server to identify the database.
            /// </summary>
            [FieldOffset(552)]
            public IntPtr ConnectionString;

        }

        /// <summary>
        /// The <see cref="WINBIO_SUPPORTED_ALGORITHMS"/> structure is the OUT payload for IOCTL_BIOMETRIC_GET_SUPPORTED_ALGORITHMS.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_SUPPORTED_ALGORITHMS
        {

            /// <summary>
            /// Specifies the total size of the payload, which includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// Specifies the HRESULT status of the I/O operation.
            /// </summary>
            public HRESULT WinBioHresult;

            /// <summary>
            /// Specifies the number of algorithms in the data block.
            /// </summary>
            public DWORD NumberOfAlgorithms;

            /// <summary>
            /// Specifies a structure of type WINBIO_DATA that contains NULL-terminated UTF-8 OID strings that represent the algorithms supported by the device.
            /// </summary>
            public WINBIO_DATA AlgorithmData;

        }

        /// <summary>
        /// The <see cref="WINBIO_UNIT_SCHEMA"/> structure describes the capabilities of a biometric unit. It is used by the <see cref="WinBioEnumBiometricUnits"/> function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WINBIO_UNIT_SCHEMA
        {

            /// <summary>
            /// A value that identifies the biometric unit.
            /// </summary>
            public WINBIO_UNIT_ID UnitId;

            /// <summary>
            /// <para>A ULONG value that specifies the type of the biometric unit. This can be one of the following values:</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <description>Meaning</description>
            /// </listheader>
            /// <item>
            /// <term><see cref="WINBIO_POOL_UNKNOWN"/></term>
            /// <description>The type is unknown.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_POOL_SYSTEM"/></term>
            /// <description>The session connects to a shared collection of biometric units managed by the service provider.</description>
            /// </item>
            /// <item>
            /// <term><see cref="WINBIO_POOL_PRIVATE"/></term>
            /// <description>The session connects to a collection of biometric units that are managed by the caller.</description>
            /// </item>
            /// </list>
            /// </summary>
            public WINBIO_POOL_TYPE PoolType;

            /// <summary>
            /// A value that specifies the type of the biometric unit. Only <see cref="WINBIO_TYPE_FINGERPRINT"/> is currently supported.
            /// </summary>
            public WINBIO_BIOMETRIC_TYPE BiometricFactor;

            /// <summary>
            /// <para>A sensor subtype defined for the biometric type specified by the BiometricFactor member. Only fingerprint types (<see cref="WINBIO_TYPE_FINGERPRINT"/>) are currently supported. The following subtypes are currently defined for fingerprints:</para>
            /// <list type="bullet">
            /// <item>
            /// <description><see cref="WINBIO_SENSOR_SUBTYPE_UNKNOWN"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_SENSOR_SUBTYPE_SWIPE"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_FP_SENSOR_SUBTYPE_TOUCH"/></description>
            /// </item>
            /// </list>
            /// </summary>
            public WINBIO_BIOMETRIC_SENSOR_SUBTYPE SensorSubType;

            /// <summary>
            /// <para>A bitmask of the biometric sensor capabilities. This can be a bitwise OR of the following values:</para>
            /// <list type="bullet">
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_SENSOR"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_MATCHING"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_DATABASE"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_PROCESSING"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_ENCRYPTION"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_NAVIGATION"/></description>
            /// </item>
            /// <item>
            /// <description><see cref="WINBIO_CAPABILITY_INDICATOR"/></description>
            /// </item>
            /// </list>
            /// </summary>
            public WINBIO_CAPABILITIES Capabilities;

            /// <summary>
            /// A string value that contains the device ID. The string can contain up to 256 Unicode characters including a terminating NULL character.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string DeviceInstanceId;

            /// <summary>
            /// A string value that contains a description of the biometric unit. The string can contain up to 256 Unicode characters including a terminating NULL character.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string Description;

            /// <summary>
            /// A string value that contains the name of the manufacturer. The string can contain up to 256 Unicode characters including a terminating NULL character.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string Manufacturer;

            /// <summary>
            /// A string value that contains the model number of the biometric unit. The string can contain up to 256 Unicode characters including a terminating NULL character.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string Model;

            /// <summary>
            /// A NULL-terminated Unicode string that contains the serial number of the biometric unit. The string can contain up to 256 Unicode characters including a terminating NULL character.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINBIO_MAX_STRING_LEN)]
            public string SerialNumber;

            /// <summary>
            /// A <see cref="WINBIO_VERSION"/> structure that contains the major and minor version numbers for the biometric unit.
            /// </summary>
            public WINBIO_VERSION FirmwareVersion;

        }

        /// <summary>
        /// The <see cref="WINBIO_UPDATE_FIRMWARE"/> structure is the IN payload for IOCTL_BIOMETRIC_UPDATE_FIRMWARE.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_UPDATE_FIRMWARE
        {

            /// <summary>
            /// Specifies the total size of the payload, which includes the fixed length structure and any variable data at the end.
            /// </summary>
            public DWORD PayloadSize;

            /// <summary>
            /// Specifies a structure of type <see cref="WINBIO_DATA"/> that contains the vendor-specific firmware image.
            /// </summary>
            public WINBIO_DATA FirmwareData;

        }

        /// <summary>
        /// The <see cref="WINBIO_VERSION"/> structure contains the software version number of a biometric service provider component.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINBIO_VERSION
        {

            /// <summary>
            /// A DWORD that contains the major version number.
            /// </summary>
            public DWORD MajorVersion;

            /// <summary>
            /// A DWORD that contains the minor version number.
            /// </summary>
            public DWORD MinorVersion;
        }


        #endregion

        #region Macros

        public static partial class Macros
        {

            public static bool FAILED(HRESULT hr)
            {
                return ((HRESULT)(hr)) < 0;
            }

            public static HRESULT HRESULT_FROM_WIN32(DWORD x)
            {
                const int FACILITY_WIN32 = 7;
                return (HRESULT) (x) <= 0 ? (HRESULT) (x) : (HRESULT) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000);
            }

    }

    #endregion

}

}