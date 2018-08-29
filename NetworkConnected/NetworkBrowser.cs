using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NetworkConnected
{
    class NetworkBrowser
    {
       
            #region Dll Imports

            
            [DllImport("Netapi32", CharSet = CharSet.Auto,
            SetLastError = true),
            SuppressUnmanagedCodeSecurityAttribute]

            
            public static extern int NetServerEnum(
                string ServerNane, // must be null
                int dwLevel,
                ref IntPtr pBuf,
                int dwPrefMaxLen,
                out int dwEntriesRead,
                out int dwTotalEntries,
                int dwServerType,
                string domain, // null for login domain
                out int dwResumeHandle
                );

            //declare the Netapi32 : NetApiBufferFree method import
            [DllImport("Netapi32", SetLastError = true),
            SuppressUnmanagedCodeSecurityAttribute]

           
            public static extern int NetApiBufferFree(
                IntPtr pBuf);

            //create a _SERVER_INFO_100 STRUCTURE
            [StructLayout(LayoutKind.Sequential)]
            public struct _SERVER_INFO_100
            {
                internal int sv100_platform_id;
                [MarshalAs(UnmanagedType.LPWStr)]
                internal string sv100_name;
            }
            #endregion
            #region Public Constructor
            
            public NetworkBrowser()
            {

            }
            #endregion
            #region Public Methods
            
            public ArrayList getNetworkComputers()
            {
                //local fields
                ArrayList networkComputers = new ArrayList();
                const int MAX_PREFERRED_LENGTH = -1;
                int SV_TYPE_WORKSTATION = 1;
                int SV_TYPE_SERVER = 2;
                IntPtr buffer = IntPtr.Zero;
                IntPtr tmpBuffer = IntPtr.Zero;
                int entriesRead = 0;
                int totalEntries = 0;
                int resHandle = 0;
                int sizeofINFO = Marshal.SizeOf(typeof(_SERVER_INFO_100));


                try
                {
                    
                    int ret = NetServerEnum(null, 100, ref buffer,
                        MAX_PREFERRED_LENGTH,
                        out entriesRead,
                        out totalEntries, SV_TYPE_WORKSTATION |
                        SV_TYPE_SERVER, null, out
                        resHandle);
                   
                    if (ret == 0)
                    {
                        
                        for (int i = 0; i < totalEntries; i++)
                        {
                           
                            tmpBuffer = new IntPtr((int)buffer +
                                       (i * sizeofINFO));
                           
                            _SERVER_INFO_100 svrInfo = (_SERVER_INFO_100)
                                Marshal.PtrToStructure(tmpBuffer,
                                        typeof(_SERVER_INFO_100));

                            //add the PC names to the ArrayList
                            networkComputers.Add(svrInfo.sv100_name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem with acessing " +
                        "network computers in NetworkBrowser " +
                        "\r\n\r\n\r\n" + ex.Message,
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    //The NetApiBufferFree function frees 
                    //the memory that the 
                    //NetApiBufferAllocate function allocates
                    NetApiBufferFree(buffer);
                }
                //return entries found
                return networkComputers;

            }
            #endregion
        }
    
}
