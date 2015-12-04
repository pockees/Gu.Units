﻿namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class ConversionsVm : INotifyPropertyChanged
    {
        private readonly Settings settings;
        private IUnit baseUnit;

        public ConversionsVm(Settings settings)
        {
            this.settings = settings;
            PrefixConversions = new PrefixConversionsVm(settings);
            PartConversions = new PartConversionsVm(settings);
            BaseUnit = settings.AllUnits.FirstOrDefault(x => x.ClassName == "SquareMetres"); // for designtime
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IUnit BaseUnit
        {
            get { return this.baseUnit; }
            set
            {
                if (Equals(value, this.baseUnit))
                {
                    return;
                }
                this.baseUnit = value;

                PrefixConversions.SetBaseUnit(value);
                PartConversions.SetBaseUnit(value);
                OnPropertyChanged();
            }
        }

        public PrefixConversionsVm PrefixConversions { get; }

        public PartConversionsVm PartConversions { get; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
