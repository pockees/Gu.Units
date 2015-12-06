﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gu.Units.Generator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Gu.Units.Generator.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;Settings xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///  &lt;DerivedUnits&gt;
        ///    &lt;DerivedUnit&gt;
        ///      &lt;ClassName&gt;SquareMetres&lt;/ClassName&gt;
        ///      &lt;Symbol&gt;m²&lt;/Symbol&gt;
        ///      &lt;QuantityName&gt;Area&lt;/QuantityName&gt;
        ///      &lt;Conversions&gt;
        ///        &lt;Conversion&gt;
        ///          &lt;ClassName&gt;SquareMillimetres&lt;/ClassName&gt;
        ///          &lt;Symbol&gt;mm²&lt;/Symbol&gt;
        ///          &lt;Formula&gt;
        ///            &lt;ConversionFactor&gt;1E-06&lt;/ConversionFactor&gt;
        ///          [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GeneratorSettings {
            get {
                return ResourceManager.GetString("GeneratorSettings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;$id&quot;: &quot;1&quot;,
        ///  &quot;Prefixes&quot;: [
        ///    {
        ///      &quot;$id&quot;: &quot;2&quot;,
        ///      &quot;Name&quot;: &quot;Nano&quot;,
        ///      &quot;Symbol&quot;: &quot;n&quot;,
        ///      &quot;Power&quot;: -9
        ///    },
        ///    {
        ///      &quot;$id&quot;: &quot;3&quot;,
        ///      &quot;Name&quot;: &quot;Micro&quot;,
        ///      &quot;Symbol&quot;: &quot;µ&quot;,
        ///      &quot;Power&quot;: -6
        ///    },
        ///    {
        ///      &quot;$id&quot;: &quot;4&quot;,
        ///      &quot;Name&quot;: &quot;Milli&quot;,
        ///      &quot;Symbol&quot;: &quot;m&quot;,
        ///      &quot;Power&quot;: -3
        ///    },
        ///    {
        ///      &quot;$id&quot;: &quot;5&quot;,
        ///      &quot;Name&quot;: &quot;Centi&quot;,
        ///      &quot;Symbol&quot;: &quot;c&quot;,
        ///      &quot;Power&quot;: -2
        ///    },
        ///    {
        ///      &quot;$id&quot;: &quot;6&quot;,
        ///      &quot;Name&quot;: &quot;Deci&quot;,
        ///      &quot;Symbol&quot;: &quot;d&quot;,
        ///      &quot;Powe [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Units {
            get {
                return ResourceManager.GetString("Units", resourceCulture);
            }
        }
    }
}
