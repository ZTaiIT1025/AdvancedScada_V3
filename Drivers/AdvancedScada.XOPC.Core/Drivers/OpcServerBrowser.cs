using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace AdvancedScada.XOPC.Core.Drivers
{



    [ComImport]
    [Guid("0002E000-0000-0000-C000-000000000046")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumGUID
    {
        int Next([In] int celt, [In] ref Guid rgelt, out int pceltFetched);
        int Skip([In] int celt);
        int Reset();
        int Clone([MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);
    }

    [ComImport]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("13486D50-4821-11D2-A494-3CB306C10000")]
    internal interface IOPCServerList
    {
        int EnumClassesOfCategories([In] int cImplemented, [In] [MarshalAs(UnmanagedType.LPArray)]
            Guid[] catidImpl, [In] int cRequired, [In] Guid[] catidReq, [MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);
        int GetClassDetails([In] ref Guid clsid, [MarshalAs(UnmanagedType.LPWStr)] out string ppszProgID, [MarshalAs(UnmanagedType.LPWStr)] out string ppszUserType);
        int CLSIDFromProgID([In] [MarshalAs(UnmanagedType.LPWStr)] string szProgId, out Guid clsid);
    }

    [ComVisible(true)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
    [ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
    public class OpcServerBrowser
    {
        private Guid CLSID_OPCEnum;
        private IOPCServerList ifSrvList;

        public OpcServerBrowser()
        {
            CLSID_OPCEnum = new Guid("{13486D51-4821-11D2-A494-3CB306C10000}");
            var typeFromCLSID = Type.GetTypeFromCLSID(CLSID_OPCEnum);
            ifSrvList = (IOPCServerList)Activator.CreateInstance(typeFromCLSID);
        }


        public OpcServerBrowser(string ComputerName)
        {
            CLSID_OPCEnum = new Guid("{13486D51-4821-11D2-A494-3CB306C10000}");
            if (ComputerName != null && ComputerName != string.Empty)
            {
                var typeFromCLSID = Type.GetTypeFromCLSID(CLSID_OPCEnum, ComputerName);
                ifSrvList = (IOPCServerList)Activator.CreateInstance(typeFromCLSID);
            }
            else
            {
                var typeFromCLSID = Type.GetTypeFromCLSID(CLSID_OPCEnum);
                ifSrvList = (IOPCServerList)Activator.CreateInstance(typeFromCLSID);
            }
        }

        public void CLSIDFromProgID(string progId, out Guid clsid)
        {
            ifSrvList.CLSIDFromProgID(progId, out clsid);

        }

        internal void EnumClassesOfCategories(int catListLength, Guid[] catList, int reqListLenght, Guid[] reqList, out object enumtemp)
        {
            ifSrvList.EnumClassesOfCategories(catListLength, catList, reqListLenght, reqList, out enumtemp);

        }

        ~OpcServerBrowser()
        {
            if (ifSrvList != null)
            {
                Marshal.ReleaseComObject(ifSrvList);
                ifSrvList = null;
            }
        }

        public void GetClassDetails(ref Guid clsid, out string progID, out string userType)
        {
            ifSrvList.GetClassDetails(ref clsid, out progID, out userType);

        }

        public void GetServerList(out string[] Servers)
        {
            Guid[] catList = { new Guid("{63D5F432-CFE4-11d1-B2C8-0060083BA1FB}"), new Guid("{63D5F430-CFE4-11d1-B2C8-0060083BA1FB}"), new Guid("{CC603642-66D7-48f1-B69A-B625E73652D7}") };
            GetServerList(catList, out Servers);
        }

        public void GetServerList(Guid[] catList, out string[] Servers)
        {
            Guid[] guidArray;
            GetServerList(catList, out Servers, out guidArray);
            guidArray = null;
        }

        public void GetServerList(out string[] Servers, out Guid[] ClsIDs)
        {
            Guid[] catList = { new Guid("{63D5F432-CFE4-11d1-B2C8-0060083BA1FB}"), new Guid("{63D5F430-CFE4-11d1-B2C8-0060083BA1FB}"), new Guid("{CC603642-66D7-48f1-B69A-B625E73652D7}") };
            GetServerList(catList, out Servers, out ClsIDs);
        }

        public void GetServerList(Guid[] catList, out string[] Servers, out Guid[] ClsIDs)
        {
            object obj2;
            Servers = null;
            ClsIDs = null;
            if (ifSrvList == null) throw new Exception(string.Format("GetServerList failed with error code {hr}", -2147467262));
            ifSrvList.EnumClassesOfCategories(catList.Length, catList, 0, null, out obj2);
            if (obj2 != null)
            {
                var o = (IEnumGUID)obj2;
                obj2 = null;
                o.Reset();
                var index = 0;
                var rgelt = CLSID_OPCEnum;
                var guidArray = new Guid[50];

                var pceltFetched = 0;

                do
                {
                    o.Next(1, ref rgelt, out pceltFetched);
                    if (pceltFetched > 0)
                    {
                        guidArray[index] = rgelt;
                        index++;
                    }
                } while (pceltFetched > 0 && index < guidArray.Length);

                Marshal.ReleaseComObject(o);
                o = null;
                var strArray = new string[index];
                var guidArray2 = new Guid[index];
                var num3 = 0;
                for (var i = 0; i < index; i++)
                {
                    string ppszProgID = null;
                    string ppszUserType = null;
                    try
                    {
                        ifSrvList.GetClassDetails(ref guidArray[i], out ppszProgID, out ppszUserType);
                        strArray[num3] = ppszProgID;
                        guidArray2[num3] = guidArray[i];
                        num3++;
                    }
                    catch
                    {
                    }
                }
                if (num3 > 0)
                {
                    Servers = new string[num3];
                    ClsIDs = new Guid[num3];
                    for (var j = 0; j < num3; j++)
                    {
                        Servers[j] = strArray[j];
                        ClsIDs[j] = guidArray2[j];
                    }
                }
                strArray = null;
                guidArray2 = null;
            }
        }

        public void GetServerList(bool V2, bool V3, out string[] Servers)
        {
            Guid[] catList = null;
            if (!V2 && !V3)
            {
                Servers = new string[0];
            }
            else
            {
                if (V2 && V3)
                    catList = new[] { new Guid("{63D5F432-CFE4-11d1-B2C8-0060083BA1FB}"), new Guid("{CC603642-66D7-48f1-B69A-B625E73652D7}") };
                else if (V2)
                    catList = new[] { new Guid("{63D5F432-CFE4-11d1-B2C8-0060083BA1FB}") };
                else if (V3) catList = new[] { new Guid("{CC603642-66D7-48f1-B69A-B625E73652D7}") };
                GetServerList(catList, out Servers);
            }
        }
    }



}
