namespace AdvancedScada.XModbus.Core.INException
{
    public static class IMessage
    {
        public const string NOT_CONNECT_TO_SERVER = "00/0x00: Timeout connecting to slave";

        public const string ILLEGAL_MODBUS_MODE = "18/0x12: Illegal modbus mode.";

        /*
         * The function code received in the query is not an allowable action for the slave.
         * This may be because the function code is only applicable to newer devices, and was not implemented in the unit selected.
         * It could also indicate that the slave is in the wrong state to process a request of this type, for example because it is unconfigured and is being asked to return register values.
         * If a Poll Program Complete command was issued, this code indicates that no program function preceded it.
         **/
        public const string ILLEGAL_FUNCTION = "01/0x01: Illegal Function.";

        /*
         * The data address received in the query is not an allowable address for the slave.
         * More specifically, the combination of reference nuMBEr and transfer length is invalid.
         * For a controller with 100 registers, a request with offset 96 and length 4 would succeed, a request with offset 96 and length 5 will generate exception 02.
         * */
        public const string ILLEGAL_DATA_ADDRESS = "02/0x02: Illegal Data Address.";

        /*
         * A value contained in the query data field is not an allowable value for the slave.
         * This indicates a fault in the structure of remainder of a complex request, such as that the implied length is incorrect.
         * It specifically does NOT mean that a data item submitted for storage in a register has a value outside the expectation of the application program, since the MODBUS protocol is unaware of the significance of any particular value of any particular register.
         * */
        public const string ILLEGAL_DATA_VALUE = "03/0x03: Illegal Data Value.";

        /*
         * An unrecoverable error occurred while the slave was attempting to perform the requested action.
         * */
        public const string SLAVE_DEVICE_FAILURE = "04/0x04: Failure In Associated Device.";

        /*
         * Specialized use in conjunction with programming commands.
         * The slave has accepted the request and is processing it, but a long duration of time will be required to do so.  
         * This response is returned to prevent a timeout error from occurring in the master. 
         * The master can next issue a Poll Program Complete message to determine if processing is completed.
         **/
        public const string ACKNOWLEDGE = "05/0x05: Acknowledge.";

        /*
         * Specialized use in conjunction with programming commands.
         * The slave is engaged in processing a long-duration program command.  
         * The master should retransmit the message later when the slave is free..
         **/
        public const string SLAVE_DEVICE_BUSY = "06/0x06: Slave Device Busy.";

        /*
         * The slave cannot perform the program function received in the query.
         * This code is returned for an unsuccessful programming request using function code 13 or 14 decimal.
         * The master should request diagnostic or error information from the slave.
         **/
        public const string NEGATIVE_KNOWLEDGEMENT = "07/0x07: NAK – Negative Acknowledgement.s";

        /*
         * Specialized use in conjunction with function codes 20 and 21 and reference type 6, to indicate that the extended file area failed to pass a consistency check.
         * The slave attempted to read extended memory or record file, but detected a parity error in memory. 
         * The master can retry the request, but service may be required on the slave device.
         **/
        public const string MEMORY_PARITY_ERROR = "08/0x08: Memory Parity Error.";

        /*
         * Specialized use in conjunction with gateways, indicates that the gateway was unable to allocate an internal communication path from the input port to the output port for processing the request.
         * Usually means the gateway is misconfigured or overloaded.
         **/
        public const string GATEWAY_PATH_UNAVAILABLE = "10/0x0A: Gateway Path Unavailable.";

        /*
         * Specialized use in conjunction with gateways, indicates that no response was obtained from the target device.
         * Usually means that the device is not present on the network. 
         **/
        public const string GATEWAY_TARGET_DEVICE_FAILED_TO_RESPOND =
            "11/0x0B: Gateway Target Device Failed to respond."; // Gateway Target Device Failed to Respond
    }
}