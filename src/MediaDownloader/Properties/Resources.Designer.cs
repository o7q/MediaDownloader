﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediaDownloader.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MediaDownloader.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to    __  ___       ___      ___                  __             __
        ///  /  |/  /__ ___/ (_)__ _/ _ \___ _    _____  / /__  ___ ____/ /__ ____
        /// / /|_/ / -_) _  / / _ `/ // / _ \ |/|/ / _ \/ / _ \/ _ `/ _  / -_) __/
        ////_/  /_/\__/\_,_/_/\_,_/____/\___/__,__/_//_/_/\___/\_,_/\_,_/\__/_/.
        /// </summary>
        internal static string asciiBanner {
            get {
                return ResourceManager.GetString("asciiBanner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap background {
            get {
                object obj = ResourceManager.GetObject("background", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap banner {
            get {
                object obj = ResourceManager.GetObject("banner", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap download_gradient {
            get {
                object obj = ResourceManager.GetObject("download_gradient", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap folder {
            get {
                object obj = ResourceManager.GetObject("folder", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MediaDownloader is a simple, lightning-fast, GUI-based tool that removes the hassle of using yt-dlp through a command-line.
        ///
        ///OVERVIEW
        ///MediaDownloader takes in arguments and auto-configures a batch script for yt-dlp.
        ///FFmpeg is then used for further media processing if specified to do so.
        ///
        ///Powered by
        ///yt-dlp: https://github.com/yt-dlp/yt-dlp
        ///FFmpeg: https://ffmpeg.org
        ///
        ///USAGE
        ///
        ///Interface
        ///
        ///File Output
        ///Name Input | Specify a name for the output file
        ///Change Path Button | Change the location the medi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string infoText {
            get {
                return ResourceManager.GetString("infoText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap x {
            get {
                object obj = ResourceManager.GetObject("x", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
