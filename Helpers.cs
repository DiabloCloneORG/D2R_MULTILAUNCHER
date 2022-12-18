using handles;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace D2R_MULTILAUNCHER
{
    class Helpers
    {
        private struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public LUID_AND_ATTRIBUTES[] Privileges;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public UInt32 Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }

        [Flags]
        private enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        private enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }

        private enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, ref int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);


        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref LUID pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TOKEN_PRIVILEGES newst, int len, IntPtr prev, IntPtr relen);


        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, uint processId);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, IntPtr lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE tokenType, out IntPtr phNewToken);

        [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CreateProcessWithTokenW(IntPtr hToken, int dwLogonFlags, string lpApplicationName, string lpCommandLine, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In] ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        const int WM_SETFOCUS = 0x0007;
        const int WM_PASTE = 0x0302;
        const int WM_SETTEXT = 0x000C;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr hWndChildAfter, string className, string windowTitle);





        public static void exportItemsFilterDataFile(string filepath, string resourceName)
        {
            #region Exporting file
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            System.IO.File.Copy(Application.StartupPath + "\\" + resourceName, filepath, true);
            #endregion
        }


        public static void saveItemsFilterDataFile(
            ConfigurationEntity configuration,
            List<ItemFilterEnhancedEntity> entities, 
            string resourceName, 
            string resourceEnhancedName)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            jso.WriteIndented = true;
            String json_data = System.Text.Json.JsonSerializer.Serialize(entities, jso);

            #region Local Application Version
            var ApplicationStartupPath = Application.StartupPath;
            if (System.IO.Directory.Exists(ApplicationStartupPath))
            {
                if (System.IO.File.Exists(ApplicationStartupPath + @"\" + resourceEnhancedName))
                {
                    System.IO.File.Delete(ApplicationStartupPath + @"\" + resourceEnhancedName);
                }
                System.IO.File.WriteAllText(ApplicationStartupPath + @"\" + resourceEnhancedName, json_data);
            }
            #endregion

            #region D2R Active Version
            List<ItemFilterBaseEntity> base_entities = new List<ItemFilterBaseEntity>();
            foreach (ItemFilterEnhancedEntity _entity in entities) 
            {
                var entity = (ItemFilterEnhancedEntity)_entity.Clone();

                #region /* Templates Override */
                if (entity.useHideTemplateOveride) 
                {
                    entity.SetAllLanguageText(configuration.ItemsFilterHideTemplateReplacement);
                }
                else if (entity.useGrayTemplateOveride) { entity.AddPrefixToAllLanguageText("ÿc5"); }
                
                else if (entity.useWhiteTemplateOveride) { entity.AddPrefixToAllLanguageText("ÿc0"); }
                else if (entity.useHighlightTemplateOveride) {
                    entity.AddPrefixToAllLanguageText("-= ");
                    entity.AddSuffixToAllLanguageText(" =-");
                }
                else if (entity.useCustomTemplate1Overide)
                {
                    entity.AddPrefixToAllLanguageText(configuration.ItemsFilterCustomTemplate1Preffix);
                    entity.AddSuffixToAllLanguageText(configuration.ItemsFilterCustomTemplate1Suffix);
                }
                else if (entity.useCustomTemplate2Overide)
                {
                    entity.AddPrefixToAllLanguageText(configuration.ItemsFilterCustomTemplate2Preffix);
                    entity.AddSuffixToAllLanguageText(configuration.ItemsFilterCustomTemplate2Suffix);
                }
                else if (entity.useCustomTemplate3Overide)
                {
                    entity.AddPrefixToAllLanguageText(configuration.ItemsFilterCustomTemplate3Preffix);
                    entity.AddSuffixToAllLanguageText(configuration.ItemsFilterCustomTemplate3Suffix);
                }
                else if (entity.useCustomTemplate4Overide)
                {
                    entity.AddPrefixToAllLanguageText(configuration.ItemsFilterCustomTemplate4Preffix);
                    entity.AddSuffixToAllLanguageText(configuration.ItemsFilterCustomTemplate4Suffix);
                }
                else if (entity.useCustomTemplate5Overide)
                {
                    entity.AddPrefixToAllLanguageText(configuration.ItemsFilterCustomTemplate5Preffix);
                    entity.AddSuffixToAllLanguageText(configuration.ItemsFilterCustomTemplate5Suffix);
                }
                #endregion

                base_entities.Add((ItemFilterBaseEntity)entity); 
            }

            String json_base_data = System.Text.Json.JsonSerializer.Serialize(base_entities, jso);

            var D2RInstallationPath = Helpers.getD2RInstallationPath();
            var RelativeFilePathToWrite = @"Data\local\lng\strings\" + resourceName;
            if (System.IO.Directory.Exists(D2RInstallationPath))
            {
                if (System.IO.File.Exists(D2RInstallationPath + @"\" + RelativeFilePathToWrite))
                {
                    System.IO.File.Delete(D2RInstallationPath + @"\" + RelativeFilePathToWrite);
                }
                System.IO.File.WriteAllText(D2RInstallationPath + @"\" + RelativeFilePathToWrite, json_base_data);
            }
            #endregion

        }


        public static void importItemsFilterDataFile(string filepath, string resourceName, string resourceEnhancedName)
        {
            try
            {
                JsonSerializerOptions jso = new JsonSerializerOptions();
                jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                jso.WriteIndented = true;

                #region Local Application Version
                if (System.IO.Directory.Exists(Application.StartupPath))
                {
                    if (System.IO.File.Exists(Application.StartupPath + @"\" + resourceEnhancedName))
                    {
                        System.IO.File.Delete(Application.StartupPath + @"\" + resourceEnhancedName);
                    }
                    System.IO.File.Copy(filepath, Application.StartupPath + @"\" + resourceEnhancedName, true);
                }
                #endregion

                string item_enhanced_jsondata = System.IO.File.ReadAllText(Application.StartupPath + @"\" + resourceEnhancedName);
                List<ItemFilterEnhancedEntity> _enhanced_entities = new List<ItemFilterEnhancedEntity>();
                _enhanced_entities = JsonSerializer.Deserialize<List<ItemFilterEnhancedEntity>>(item_enhanced_jsondata);

                List<ItemFilterBaseEntity> base_entities = new List<ItemFilterBaseEntity>();
                foreach (ItemFilterEnhancedEntity entity in _enhanced_entities) { base_entities.Add((ItemFilterBaseEntity)entity); }
                
                String json_base_data = System.Text.Json.JsonSerializer.Serialize(base_entities, jso);

                var D2RInstallationPath = Helpers.getD2RInstallationPath();
                var RelativeFilePathToWrite = @"Data\local\lng\strings\" + resourceName;
                if (System.IO.Directory.Exists(D2RInstallationPath))
                {
                    if (System.IO.File.Exists(D2RInstallationPath + @"\" + RelativeFilePathToWrite))
                    {
                        System.IO.File.Delete(D2RInstallationPath + @"\" + RelativeFilePathToWrite);
                    }
                    System.IO.File.WriteAllText(D2RInstallationPath + @"\" + RelativeFilePathToWrite, json_base_data);
                }

            }
            catch
            {

            }

        }

        public static void restoreItemsFilterItemNameAffixesOriginalDataFile()
        {
            var resourceName = "item-nameaffixes.json";
            var D2RInstallationPath = Helpers.getD2RInstallationPath();
            var RelativeFilePathToRestore = @"Data\local\lng\strings\" + resourceName;
            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_nameaffixes;
                        
            if (System.IO.Directory.Exists(D2RInstallationPath))
            {
                if (System.IO.File.Exists(D2RInstallationPath + @"\" + RelativeFilePathToRestore))
                {
                    System.IO.File.Delete(D2RInstallationPath + @"\" + RelativeFilePathToRestore);
                }
                System.IO.File.WriteAllBytes(D2RInstallationPath + @"\" + RelativeFilePathToRestore, file_data);
            }
        }

        public static void restoreItemsFilterCustomItemNameAffixesDataFile()
        {
            var resourceName = "item-nameaffixes.json";
            var ApplicationStartupPath = Application.StartupPath;
            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_nameaffixes;

            if (System.IO.Directory.Exists(ApplicationStartupPath))
            {
                if (System.IO.File.Exists(ApplicationStartupPath + @"\" + resourceName))
                {
                    System.IO.File.Delete(ApplicationStartupPath + @"\" + resourceName);
                }
                System.IO.File.WriteAllBytes(ApplicationStartupPath + @"\" + resourceName, file_data);
            }
        }

        public static void restoreItemsFilterItemNamesOriginalDataFile()
        {
            var resourceName = "item-names.json";
            var D2RInstallationPath = Helpers.getD2RInstallationPath();
            var RelativeFilePathToRestore = @"Data\local\lng\strings\" + resourceName;
            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_names;

            if (System.IO.Directory.Exists(D2RInstallationPath))
            {
                if (System.IO.File.Exists(D2RInstallationPath + @"\" + RelativeFilePathToRestore))
                {
                    System.IO.File.Delete(D2RInstallationPath + @"\" + RelativeFilePathToRestore);
                }
                System.IO.File.WriteAllBytes(D2RInstallationPath + @"\" + RelativeFilePathToRestore, file_data);
            }
        }

        public static void restoreItemsFilterCustomItemNamesDataFile()
        {
            var resourceName = "item-names.json";
            var ApplicationStartupPath = Application.StartupPath;
            byte[] file_data =  D2R_MULTILAUNCHER3.Properties.Resources.item_names;

            if (System.IO.Directory.Exists(ApplicationStartupPath))
            {
                if (System.IO.File.Exists(ApplicationStartupPath + @"\" + resourceName))
                {
                    System.IO.File.Delete(ApplicationStartupPath + @"\" + resourceName);
                }
                System.IO.File.WriteAllBytes(ApplicationStartupPath + @"\" + resourceName, file_data);
            }
        }

        public static void restoreItemsFilterItemRunesOriginalDataFile()
        {
            var resourceName = "item-runes.json";
            var D2RInstallationPath = Helpers.getD2RInstallationPath();
            var RelativeFilePathToRestore = @"Data\local\lng\strings\" + resourceName;
            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_runes;

            if (System.IO.Directory.Exists(D2RInstallationPath))
            {
                if (System.IO.File.Exists(D2RInstallationPath + @"\" + RelativeFilePathToRestore))
                {
                    System.IO.File.Delete(D2RInstallationPath + @"\" + RelativeFilePathToRestore);
                }
                System.IO.File.WriteAllBytes(D2RInstallationPath + @"\" + RelativeFilePathToRestore, file_data);
            }
        }

        public static void restoreItemsFilterCustomItemRunesDataFile()
        {
            var resourceName = "item-runes.json";
            var ApplicationStartupPath = Application.StartupPath;
            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_runes;

            if (System.IO.Directory.Exists(ApplicationStartupPath))
            {
                if (System.IO.File.Exists(ApplicationStartupPath + @"\" + resourceName))
                {
                    System.IO.File.Delete(ApplicationStartupPath + @"\" + resourceName);
                }
                System.IO.File.WriteAllBytes(ApplicationStartupPath + @"\" + resourceName, file_data);
            }
        }

        public static void restoreItemsFilterOriginalDataFiles()
        {
            restoreItemsFilterItemNameAffixesOriginalDataFile();
            restoreItemsFilterItemNamesOriginalDataFile();
            restoreItemsFilterItemRunesOriginalDataFile();
        }


        public static List<ItemFilterBaseEntity> getItemsFilterOriginalDataEntitiesByResourceName(string resourceName)
        {
            List<ItemFilterBaseEntity> _entities = new List<ItemFilterBaseEntity>();

            try
            {
                switch (resourceName)
                {
                    case "item-runes.json":
                        {
                            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_runes;

                            using (Stream stream = new MemoryStream(file_data))
                            {
                                JsonSerializerOptions jso = new JsonSerializerOptions();
                                jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                                jso.WriteIndented = true;
                                _entities = JsonSerializer.Deserialize<List<ItemFilterBaseEntity>>(stream, jso);
                            }
                            break;
                        }
                    case "item-names.json":
                        {
                            byte[] file_data = D2R_MULTILAUNCHER3.Properties.Resources.item_names;

                            using (Stream stream = new MemoryStream(file_data))
                            {
                                JsonSerializerOptions jso = new JsonSerializerOptions();
                                jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                                jso.WriteIndented = true;
                                _entities = JsonSerializer.Deserialize<List<ItemFilterBaseEntity>>(stream, jso);
                            }
                            break;
                        }
                    case "item-nameaffixes.json":
                        {
                            byte[] file_data =  D2R_MULTILAUNCHER3.Properties.Resources.item_nameaffixes;

                            using (Stream stream = new MemoryStream(file_data))
                            {
                                JsonSerializerOptions jso = new JsonSerializerOptions();
                                jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                                jso.WriteIndented = true;
                                _entities = JsonSerializer.Deserialize<List<ItemFilterBaseEntity>>(stream, jso);
                            }
                            break;
                        }
                }
            }
            catch { }

            return _entities;            
        }




        public static string createNewUniqueSeed()
        {
            StringBuilder salt = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 64; i++)
            {
                salt.Append(rnd.Next(0, 9).ToString());
            }
            return salt.ToString();
        }

        public static string getCurrentUniqueSeed()
        {
            try
            {
                string salt = null;
                string path = Application.StartupPath + "\\random.salt";
                if (!File.Exists(path))
                {
                    salt = createNewUniqueSeed();
                    System.IO.File.WriteAllText(path, salt);
                }
                else
                {
                    System.Text.RegularExpressions.Regex regexValidSalt = new System.Text.RegularExpressions.Regex(@"[0-9]{64}");
                    salt = System.IO.File.ReadAllText(path);
                    if (String.IsNullOrEmpty(salt)) 
                    {
                        salt = createNewUniqueSeed();
                        System.IO.File.WriteAllText(path, salt);
                    }
                    
                    if (!regexValidSalt.IsMatch(salt))
                    {
                        salt = createNewUniqueSeed();
                        System.IO.File.WriteAllText(path, salt);
                    }
                }
                return salt;
            }
            catch 
            {
                return null;
            }

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);


        [SupportedOSPlatform("windows")]
        public static Process LaunchGame(String arguments)
        {
            Process newprocess = null;
            try
            {
                string D2RPath = Helpers.getD2RInstallationPath();
                int process_id = 0;

                Helpers.RunAsDesktopUser(D2RPath + "\\D2R.exe", arguments, out process_id);
                if (process_id > 0)
                {
                    newprocess = Process.GetProcessById(process_id);
                    return newprocess;
                }
                else { return null; }
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                return null;
            }
            catch (InvalidOperationException ioex)
            {
                Console.WriteLine(ioex.Message);
                return null;
            }
            catch 
            {
                return null;
            }
        }

        [SupportedOSPlatform("windows")]
        public static string getD2RInstallationPath()
        {
            string val = "";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Diablo II Resurrected");
                if (key != null)
                {
                    Object o = key.GetValue("InstallLocation");
                    if (o != null)
                    {
                        val = o.ToString();
                    }
                    key.Close();
                }

            }
            catch { }
            return val;
        }

        [SupportedOSPlatform("windows")]
        public static string getBNetInstallationPath()
        {
            string val = "";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Battle.net");
                if (key != null)
                {
                    Object o = key.GetValue("InstallLocation");
                    if (o != null)
                    {
                        val = o.ToString();
                    }
                    key.Close();
                }
            }
            catch { }
            return val;
        }


        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int memcmp(byte[] b1, byte[] b2, long count);

        public static bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            // Validate buffers are the same length.
            // This also ensures that the count does not exceed the length of either buffer.  
            return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
        }

        public static List<AccountInfo> getAccountProfiles(string masterPassword, string Salt)
        {
            List<AccountInfo> _accounts = new List<AccountInfo>();
            try
            {
                var account_directory_info = new DirectoryInfo(Application.StartupPath);
                foreach (var file in account_directory_info.EnumerateFiles("*.encrypted.json"))
                {
                    try
                    {
                        AccountInfo accountObj = new AccountInfo();
                        accountObj.ReadFromBinaryFile(file.FullName, masterPassword, Salt);
                        _accounts.Add(accountObj);
                    }
                    catch { }
                }
            }
            catch { }
            return _accounts;
        }

        public static void RunAsDesktopUser(string fileName, string cmdline, out int process_id)
        {
            process_id = 0;

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));

            // To start process as shell user you will need to carry out these steps:
            // 1. Enable the SeIncreaseQuotaPrivilege in your current token
            // 2. Get an HWND representing the desktop shell (GetShellWindow)
            // 3. Get the Process ID(PID) of the process associated with that window(GetWindowThreadProcessId)
            // 4. Open that process(OpenProcess)
            // 5. Get the access token from that process (OpenProcessToken)
            // 6. Make a primary token with that token(DuplicateTokenEx)
            // 7. Start the new process with that primary token(CreateProcessWithTokenW)

            var hProcessToken = IntPtr.Zero;
            // Enable SeIncreaseQuotaPrivilege in this process.  (This won't work if current process is not elevated.)
            try
            {
                var process = GetCurrentProcess();
                if (!OpenProcessToken(process, 0x0020, ref hProcessToken))
                    return;

                var tkp = new TOKEN_PRIVILEGES
                {
                    PrivilegeCount = 1,
                    Privileges = new LUID_AND_ATTRIBUTES[1]
                };

                if (!LookupPrivilegeValue(null, "SeIncreaseQuotaPrivilege", ref tkp.Privileges[0].Luid))
                    return;

                tkp.Privileges[0].Attributes = 0x00000002;

                if (!AdjustTokenPrivileges(hProcessToken, false, ref tkp, 0, IntPtr.Zero, IntPtr.Zero))
                    return;
            }
            finally
            {
                CloseHandle(hProcessToken);
            }

            // Get an HWND representing the desktop shell.
            // CAVEATS:  This will fail if the shell is not running (crashed or terminated), or the default shell has been
            // replaced with a custom shell.  This also won't return what you probably want if Explorer has been terminated and
            // restarted elevated.
            var hwnd = GetShellWindow();
            if (hwnd == IntPtr.Zero)
                return;

            var hShellProcess = IntPtr.Zero;
            var hShellProcessToken = IntPtr.Zero;
            var hPrimaryToken = IntPtr.Zero;
            try
            {
                // Get the PID of the desktop shell process.
                uint dwPID;
                if (GetWindowThreadProcessId(hwnd, out dwPID) == 0)
                    return;

                // Open the desktop shell process in order to query it (get the token)
                hShellProcess = OpenProcess(ProcessAccessFlags.QueryInformation, false, dwPID);
                if (hShellProcess == IntPtr.Zero)
                    return;

                // Get the process token of the desktop shell.
                if (!OpenProcessToken(hShellProcess, 0x0002, ref hShellProcessToken))
                    return;

                var dwTokenRights = 395U;

                // Duplicate the shell's process token to get a primary token.
                // Based on experimentation, this is the minimal set of rights required for CreateProcessWithTokenW (contrary to current documentation).
                if (!DuplicateTokenEx(hShellProcessToken, dwTokenRights, IntPtr.Zero, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenPrimary, out hPrimaryToken))
                    return;

                // Start the target process with the new token.
                var si = new STARTUPINFO();
                var pi = new PROCESS_INFORMATION();
                
                if (!CreateProcessWithTokenW(hPrimaryToken, 0, fileName, cmdline, 0, IntPtr.Zero, Path.GetDirectoryName(fileName), ref si, out pi))
                {
                    return;
                }

                process_id = pi.dwProcessId;
            }
            finally
            {
                CloseHandle(hShellProcessToken);
                CloseHandle(hPrimaryToken);
                CloseHandle(hShellProcess);
            }

        }


        public static void KillD2RInstanceCheckerHandle(Process gameProcess)
        {


            ushort checkford2launcherhandle = 0;
            IntPtr checkford2launcherhandleptr = IntPtr.Zero;

            try
            {
                if (gameProcess == null || gameProcess.Id <= 0)
                {
                    Console.WriteLine("KillD2RInstanceChecker -> Process not found.");
                    return;
                }

                int pid = gameProcess.Id;
                using (SafeFileHandle processHandle = Native.OpenProcess(Native.PROCESS_DUP_HANDLE, false, pid))
                {
                    if (processHandle.IsInvalid)
                    {
                        Console.WriteLine("KillD2RInstanceChecker -> Process not found.");
                        return;
                    }

                    foreach (var systemHandle in ProcessHandles.getHandles(pid))
                    {
                        SafeFileHandle dupHandle;

                        if (Native.NtDuplicateObject(
                            processHandle,
                            (IntPtr)systemHandle.Handle,
                            Native.GetCurrentProcess(),
                            out dupHandle,
                            0,
                            0,
                            0
                            ) != NtStatus.Success)
                        {
                            continue;
                        }

                        using (dupHandle)
                        {
                            string objectName = ProcessHandles.getObjectNameInformation(dupHandle);

                            if (!String.IsNullOrEmpty(objectName))
                            {
                                if (objectName.Contains("DiabloII Check For Other Instances"))
                                {
                                    checkford2launcherhandle = systemHandle.Handle;
                                    checkford2launcherhandleptr = (IntPtr)systemHandle.Handle;
                                    Console.WriteLine("Closing Handle: " + System.String.Format("0x{0:X}", checkford2launcherhandle));

                                }
                            }
                        }

                        if (checkford2launcherhandle > 0)
                        {
                            SafeFileHandle dupHandle2;

                            if (Native.NtDuplicateObject(
                                processHandle,
                                (IntPtr)checkford2launcherhandle,
                                IntPtr.Zero,
                                out dupHandle2,
                                0,
                                0,
                                1
                                ) != NtStatus.Success)
                            {
                                continue;
                            }

                            Helpers.CloseHandle(dupHandle2.DangerousGetHandle());
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public static void KillAllD2RInstanceCheckerHandle()
        {
            Process[] ps1 = Process.GetProcessesByName("D2R");
            foreach (Process p in ps1)
            {
                try
                {
                    KillD2RInstanceCheckerHandle(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void killAllBnetLaunchers()
        {
            Process[] ps1 = Process.GetProcessesByName("D2R");

            foreach (Process p in ps1)
            {
                int nRet;
                StringBuilder className = new StringBuilder(256);
                nRet = GetClassName(p.MainWindowHandle, className, className.Capacity);

                if (nRet != 0)
                {

                    if ("qt5qwindowicon" == className.ToString().ToLowerInvariant() ||
                        "chrome_widgetwin_0" == className.ToString().ToLowerInvariant())
                    {

                        try
                        {
                            p.Kill();
                        }
                        catch { }

                    }
                }
            }
        }



    }
}



#region Interop




#endregion



