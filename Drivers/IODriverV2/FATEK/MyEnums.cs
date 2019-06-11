using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.XFATEK.Core.Comm
{

    #region The gist read the system status of PLC

    /// <summary>
    /// B0： RUN/STOP.
    /// </summary>
    public enum PLCMode
    {
        STOP = 0,
        RUN = 1,
    }


    /// <summary>
    /// B2：Ladder checksum error/NORMAL.
    /// </summary>
    public enum LADDER_CHECKSUM
    {
        NORMAL = 0,
        ERROR = 1
    }

    /// <summary>
    /// B3： USE ROM PACK/NOT USE
    /// </summary>
    public enum USE_ROM_PACK_OR_NOT_USE
    {
        NOT_USE_ROM_PACK = 0,
        USE_ROM_PACK = 1
    }

    /// <summary>
    /// B4： WDT Timeout/NORMAL
    /// </summary>
    public enum WDT_TIMEOUT_OR_NORMAL
    {
        NORMAL = 0,
        WDT_TIMEOUT = 1
    }

    /// <summary>
    /// B5： SET ID/NOT SET ID
    /// </summary>
    public enum SET_ID_OR_NOT_SET_ID
    {
        NOT_SET_ID = 0,
        SET_ID = 1,
    }


    /// <summary>
    /// 
    /// </summary>
    public enum EMERGENCY_STOP_OR_NORMAL
    {
        NORMAL = 0,
        EMERGENCY_STOP = 1,
    }

    #endregion

    public enum MemoryType
    {
        /// <summary>
        /// Input discrete
        /// </summary>
        X = 0,

        /// <summary>
        /// Output relay
        /// </summary>
        Y = 1,

        /// <summary>
        /// Internal relay
        /// </summary>
        M = 2,

        /// <summary>
        /// Step relay
        /// </summary>
        S = 3,

        /// <summary>
        /// Timer discrete
        /// </summary>
        T = 4,

        /// <summary>
        /// Counter discrete
        /// </summary>
        C = 5,

        /// <summary>
        /// Timer register
        /// </summary>
        RT = 6,

        /// <summary>
        /// Counter register
        /// </summary>
        RC = 7,

        /// <summary>
        /// Data register
        /// </summary>
        R = 8,

        /// <summary>
        /// Data register
        /// </summary>
        D = 9,
    }

    public enum DataType
    {
        BOOL = 1,
        BYTE = 2,
        CHAR = 3,
        INT = 4,
        WORD = 5,
        DINT = 6,
        DWORD = 7,
        REAL = 8,
    }

    public enum CommandCode
    {
        /// <summary>
        /// The gist read the system status of PLC.
        /// </summary>
        PLC_STATUS = 0x40,

        /// <summary>
        /// Control RUN/STOP of PLC.
        /// </summary>
        CONTROL_RUN_STOP = 0x41,

        /// <summary>
        /// Single discrete control.
        /// </summary>
        SINGLE_DISCRETE_CONTROL = 0x42,

        /// <summary>
        /// The status reading of ENABLE/DISABLE of continuous discrete.
        /// </summary>
        READ_ENABLE_DISABLE = 0x43,

        /// <summary>
        /// The status reading of continuous discrete.
        /// </summary>
        THE_STATUS_READING_OF_CONTINUOUS_DISCRETE = 0x44,

        /// <summary>
        /// Write the status to continuous discrete.
        /// </summary>
        WRITE_THE_STATUS_TO_CONTINUOUS_DISCRETE = 0x45,

        //Read the data from continuous registers.
        READ_THE_DATA_FROM_CONTINUOUS_REGISTERS = 0x46,

        /// <summary>
        /// Write to continuous registers.
        /// </summary>
        WRITE_TO_CONTINUOUS_REGISTERS = 0x47,

        /// <summary>
        /// Mixed read the random discrete status of register data.
        /// </summary>
        MIXED_READ_THE_RADOM_DISCRETE_STATUS_OF_REGISTER_DATA = 0x48,

        /// <summary>
        /// Mixed write the random discrete status of register data.
        /// </summary>
        MIXED_WRITE_RADOM_DISCRETE_STATUS_OF_REGISTER_DATA = 0x49,

        /// <summary>
        /// Loop back testing
        /// </summary>
        LOOP_BACK_TESTING = 0x4E,

        /// <summary>
        /// The detail read the system status of PLC.
        /// </summary>
        THE_DETAIL_READ_THE_SYSTEM_STATUS_OF_PLC = 0x53
    }

    public enum RunningCode
    {
        Disable = 1,
        Enable = 2,
        Set = 3,
        Reset = 4
    }
}
