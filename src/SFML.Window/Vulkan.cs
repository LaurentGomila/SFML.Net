using System;
using System.Runtime.InteropServices;
using System.Security;
using SFML.System;

namespace SFML.Window
{
    /// <summary>Vulkan helper functions</summary>
    public static class Vulkan
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Tell whether or not the system supports Vulkan
        ///
        /// This function should always be called before using
        /// the Vulkan features. If it returns false, then
        /// any attempt to use Vulkan will fail.
        /// 
        /// If only compute is required, set <paramref name="requireGraphics"/>
        /// to false to skip checking for the extensions necessary
        /// for graphics rendering.
        /// </summary>
        /// <param name="requireGraphics"> True to skip checking for graphics extensions, false otherwise </param>
        /// <returns>True if Vulkan is supported, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool IsAvailable(bool requireGraphics = true) => sfVulkan_isAvailable(requireGraphics);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the address of a Vulkan function
        /// </summary>
        /// <param name="name"> Name of the function to get the address of </param>
        /// <returns>Address of the Vulkan function, <see cref="IntPtr.Zero"/> on failure</returns>
        ////////////////////////////////////////////////////////////
        public static IntPtr GetFunction(string name) => sfVulkan_getFunction(name);

        // TODO: Implement GetGraphicsRequiredInstanceExtensions

        #region Imports
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfVulkan_isAvailable(bool requireGraphics);

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVulkan_getFunction(string name);

        // TODO: Import sfVulkan_getGraphicsRequiredInstanceExtensions
        #endregion
    }
}