﻿namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;
    using Reactive;

    public class MainVm : INotifyPropertyChanged
    {
        public static readonly MainVm Instance = new MainVm();
        private readonly Settings settings;
        private readonly ConversionsVm conversions;
        private string nameSpace;

        private MainVm()
        {
            this.settings = Settings.FromResource;
            this.NameSpace = Settings.ProjectName;
            this.BaseUnits = new ObservableCollection<BaseUnitViewModel>(this.settings.BaseUnits.Select(x => new BaseUnitViewModel(x)));
            this.BaseUnits.ObserveCollectionChangedSlim(false)
                .Subscribe(this.OnBaseUnitsChanged);
            this.DerivedUnits = new ObservableCollection<DerivedUnitViewModel>(this.settings.DerivedUnits.Select(x => new DerivedUnitViewModel(x)));

            this.DerivedUnits.ObserveCollectionChangedSlim(false)
                .Subscribe(this.OnDerivedUnitsChanged);
            this.conversions = new ConversionsVm(this.settings);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Prefix> Prefixes => this.settings.Prefixes;

        public ObservableCollection<BaseUnitViewModel> BaseUnits { get; }

        public ObservableCollection<DerivedUnitViewModel> DerivedUnits { get; }

        public ConversionsVm Conversions => this.conversions;

        public string NameSpace
        {
            get
            {
                return this.nameSpace;
            }
            set
            {
                if (value == this.nameSpace)
                {
                    return;
                }
                this.nameSpace = value;
                this.OnPropertyChanged();
            }
        }

        public void Save()
        {
            Persister.Save(Persister.SettingsFileName);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnBaseUnitsChanged(NotifyCollectionChangedEventArgs args)
        {
            var typedArgs = args.As<BaseUnitViewModel>();
            switch (typedArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    // NOP
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.settings.BaseUnits.Remove(typedArgs.OldItems.Single().Unit);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDerivedUnitsChanged(NotifyCollectionChangedEventArgs args)
        {
            var typedArgs = args.As<DerivedUnitViewModel>();
            switch (typedArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    // NOP
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.settings.DerivedUnits.Remove(typedArgs.OldItems.Single().Unit);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
