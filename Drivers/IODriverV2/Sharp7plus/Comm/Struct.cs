using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IODriverV2.Sharp7plus.Profinet;
using System;

namespace AdvancedScada.IODriverV2.Sharp7plus.Comm
{
    /// <summary>
    /// Contains the method to convert a C# struct to S7 data types
    /// </summary>
    public static class Struct
    {

        public static int GetStructSize(DataBlock structType)
        {
            double numBytes = 0.0;

            var infos = structType.Tags;
            foreach (Tag info in infos)
            {
                switch (info.DataType.ToString())
                {
                    case "Bit":
                        numBytes += 0.125;
                        break;
                    case "Byte":
                        numBytes = Math.Ceiling(numBytes);
                        numBytes++;
                        break;
                    case "String":

                        numBytes += 64;
                        break;
                    case "Word":
                    case "Int":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 2;

                        break;
                    case "DWord":
                    case "UInt32":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 4;
                        break;
                    case "Real":
                    case "Double":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 4;
                        break;

                }
            }
            return (int)numBytes;
        }

        /// <summary>
        /// Creates a struct of a specified type by an array of bytes.
        /// </summary>
        /// <param name="structType">The struct type</param>
        /// <param name="bytes">The array of bytes</param>
        /// <returns>The object depending on the struct type or null if fails(array-length != struct-length</returns>
        public static object FromBytes(DataBlock structType, byte[] bytes, Plc plc)
        {
            if (bytes == null)
                return null;

            //if (bytes.Length != GetStructSize(structType))
            //    return null;

            // and decode it
            int bytePos = 0;
            int bitPos = 0;
            double numBytes = 0.0;


            var infos = structType.Tags;
            foreach (Tag info in infos)
            {
                switch (info.DataType.ToString())
                {
                    case "Bit":
                        // get the value
                        bytePos = (int)Math.Floor(numBytes);
                        bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                        bool dbdbit = Sharp7.S7.GetBitAt(bytes, bytePos, bitPos);
                        if (dbdbit)
                        {
                            info.Value = true;
                            info.Checked = true;
                            info.Enabled = true;
                            info.Visible = true;
                            info.ValueSelect1 = true;
                            info.ValueSelect2 = true;
                            info.Timestamp = DateTime.Now;
                        }


                        else
                        {
                            info.Value = false;
                            info.Checked = false;
                            info.Enabled = false;
                            info.Visible = false;
                            info.ValueSelect1 = false;
                            info.ValueSelect2 = false;
                            info.Timestamp = DateTime.Now;
                        }

                        numBytes += 0.125;

                        break;
                    case "Byte":
                        numBytes = Math.Ceiling(numBytes);
                        info.Value((bytes[(int)numBytes]));
                        info.Timestamp = DateTime.Now;
                        numBytes++;
                        break;
                    case "Int":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        int db1dbw2 = Sharp7.S7.GetIntAt(bytes, (int)numBytes + 1);

                        info.Value = db1dbw2;
                        info.Timestamp = DateTime.Now;
                        numBytes += 2;
                        break;
                    case "Word":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        double db1dbw16 = Sharp7.S7.GetWordAt(bytes, (int)numBytes);
                        info.Value = db1dbw16;





                        info.Timestamp = DateTime.Now;
                        numBytes += 2;
                        break;
                    case "DWord":

                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        double db1dbd8 = Sharp7.S7.GetDWordAt(bytes, (int)numBytes); ;
                        info.Value = db1dbd8;

                        info.Timestamp = DateTime.Now;
                        numBytes += 4;
                        break;
                    case "Real":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        double db1dbd4 = Sharp7.S7.GetRealAt(bytes, (int)numBytes);
                        info.Value = db1dbd4;
                        info.Timestamp = DateTime.Now;
                        numBytes += 4;
                        break;
                    case "Single":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // hier auswerten
                        info.Value = S7.Net.Types.Single.FromByteArray(new byte[] { bytes[(int)numBytes],
                                                                           bytes[(int)numBytes + 1],
                                                                           bytes[(int)numBytes + 2],
                                                                           bytes[(int)numBytes + 3] });
                        numBytes += 4;
                        break;
                    case "String":


                        string db3dbd18 = Sharp7.S7.GetStringAt(bytes, (int)numBytes);
                        info.Value = db3dbd18;
                        info.Timestamp = DateTime.Now;
                        numBytes += 64;
                        break;
                    default:

                        break;
                }
            }
            return infos;
        }
    }
}
