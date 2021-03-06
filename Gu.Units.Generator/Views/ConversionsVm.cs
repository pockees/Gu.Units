﻿namespace Gu.Units.Generator
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using JetBrains.Annotations;
    using Reactive;
    using Wpf.Reactive;

    public class ConversionsVm : INotifyPropertyChanged
    {
        private readonly SerialDisposable subscription = new SerialDisposable();
        private readonly Settings settings;
        private readonly ReadOnlySerialView<IConversion> allConversions = new ReadOnlySerialView<IConversion>();
        private Unit unit;
        private IConversion selectedConversion;
        private BaseUnitViewModel selectedBaseUnit;
        private DerivedUnitViewModel selectedDerivedUnit;

        public ConversionsVm(Settings settings)
        {
            this.settings = settings;
            this.PrefixConversions = new PrefixConversionsVm(settings);
            this.PartConversions = new PartConversionsVm(settings);
            this.Unit = settings.AllUnits.FirstOrDefault(x => x.QuantityName == "Angle"); // for designtime
            this.DeleteSelectedCommand = new RelayCommand(this.DeleteSelected);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Unit Unit
        {
            get { return this.unit; }
            set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }
                this.SelectedConversion = null;
                this.unit = value;
                this.UpdateAllConversionsSubscription();

                this.PrefixConversions.SetBaseUnit(value);
                this.PartConversions.SetUnit(value);
                this.FactorConversions.SetUnit(value);
                this.CustomConversions.SetUnit(value);
                this.OnPropertyChanged();
            }
        }

        public PrefixConversionsVm PrefixConversions { get; }

        public PartConversionsVm PartConversions { get; }

        public FactorConversionsVm FactorConversions { get; } = new FactorConversionsVm();

        public CustomConversionsVm CustomConversions { get; } = new CustomConversionsVm();

        public IConversion SelectedConversion
        {
            get { return this.selectedConversion; }
            set
            {
                if (Equals(value, this.selectedConversion))
                    return;
                this.selectedConversion = value;
                this.OnPropertyChanged();
            }
        }

        public IReadOnlyObservableCollection<IConversion> AllConversions => this.allConversions;

        public ICommand DeleteSelectedCommand { get; }

        public object SelectedBaseUnit
        {
            get { return this.selectedBaseUnit; }
            set
            {
                var selected = value as BaseUnitViewModel;
                if (Equals(selected, this.selectedBaseUnit))
                {
                    return;
                }
                this.selectedBaseUnit = selected;
                if (selected != null && !selected.IsUnknown)
                {
                    this.Unit = selected.Unit;
                }
                this.OnPropertyChanged();
            }
        }

        public object SelectedDerivedUnit
        {
            get { return this.selectedDerivedUnit; }
            set
            {
                var selected = value as DerivedUnitViewModel;
                if (Equals(selected, this.selectedDerivedUnit))
                {
                    return;
                }
                this.selectedDerivedUnit = selected;
                if (selected != null && !selected.IsUnknown)
                {
                    this.Unit = selected.Unit;
                }

                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateAllConversionsSubscription()
        {
            this.allConversions.SetSource(null);
            this.allConversions.SetSource(this.unit.AllConversions);
            if (this.unit == null)
            {
                this.subscription.Disposable.Dispose();
                this.allConversions.SetSource(null);
            }
            else
            {
                var observable = Observable.Merge(this.unit.FactorConversions.ObservePropertyChangedSlim(),
                                                  this.unit.FactorConversions.Select(x => x.PrefixConversions.ObservePropertyChangedSlim()).Merge(),
                                                  this.unit.CustomConversions.ObservePropertyChangedSlim(),
                                                  this.unit.PrefixConversions.ObservePropertyChangedSlim(),
                                                  this.unit.PartConversions.ObservePropertyChangedSlim());
                this.subscription.Disposable = observable.Subscribe(_ => this.UpdateAllConversionsSubscription());
            }
        }

        private void DeleteSelected()
        {
            if (this.selectedConversion == null || this.unit == null)
            {
                return;
            }

            TryRemove(this.unit.FactorConversions, this.selectedConversion);
            foreach (var factorConversion in this.unit.FactorConversions)
            {
                TryRemove(factorConversion.PrefixConversions, this.selectedConversion);
            }

            TryRemove(this.unit.CustomConversions, this.selectedConversion);
            TryRemove(this.unit.PrefixConversions, this.selectedConversion);
            TryRemove(this.unit.PartConversions, this.selectedConversion);
        }

        private static void TryRemove<T>(ObservableCollection<T> collection, IConversion item)
            where T : IConversion
        {
            ((IList)collection).Remove(item);
        }
    }
}
