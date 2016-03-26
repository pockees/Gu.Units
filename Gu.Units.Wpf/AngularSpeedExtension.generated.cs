﻿namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="AngularSpeed"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(AngularSpeed))]
    public class AngularSpeedExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.AngularSpeedExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.AngularSpeed"/>.</param>
        public AngularSpeedExtension(AngularSpeed value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="AngularSpeed"/> value
        /// </summary>		
        public AngularSpeed Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}