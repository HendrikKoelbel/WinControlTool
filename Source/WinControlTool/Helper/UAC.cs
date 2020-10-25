using System;
using System.Security.Principal;

namespace WinControlTool.Helper
{
    public class UAC
    {
        #region User is ... section

        public bool IsAdmin()
        {
            bool isAdmin;
            WindowsIdentity user = null;
            try
            {
                user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            finally
            {
                user?.Dispose();
            }
            return isAdmin;
        }
        public bool IsAdmin(WindowsIdentity windowsIdentity)
        {
            bool isAdmin;
            try
            {
                if (windowsIdentity == null)
                {
                    windowsIdentity = WindowsIdentity.GetCurrent();
                }
                WindowsPrincipal principal = new WindowsPrincipal(windowsIdentity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            finally
            {
                windowsIdentity?.Dispose();
            }
            return isAdmin;
        }

        #endregion
    }
}
