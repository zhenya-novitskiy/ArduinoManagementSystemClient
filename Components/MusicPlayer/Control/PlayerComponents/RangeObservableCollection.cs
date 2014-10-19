using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    public class RangeObservableCollection<T> : ObservableCollection<T> where T : ISelectable , new()
    {
        public int SelectedIndex { get; set; }

        private bool _SuppressCollectionChanged = false;

        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        //protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        //{
        //    if (!_suppressNotification)
        //        base.OnCollectionChanged(e);
        //}

        protected virtual void OnCollectionChangedMultiItem(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handlers = this.CollectionChanged;
            if (handlers != null)
                foreach (NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList())
                {
                    handler(this, !(handler.Target is ICollectionView)? e : new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_SuppressCollectionChanged)
            {
                base.OnCollectionChanged(e);
                if (CollectionChanged != null)
                    CollectionChanged.Invoke(this, e);
            }
        }

        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            _SuppressCollectionChanged = true;

            foreach (T item in list)
            {
                Add(item);
            }
            _SuppressCollectionChanged = false;


            foreach (var item in list)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            }
            
            
        }
        protected override void ClearItems()
        {
            if (this.Count == 0) return;

            List<T> removed = new List<T>(this);
            _SuppressCollectionChanged = true;
            base.ClearItems();
            _SuppressCollectionChanged = false;
            OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed));
        }

        public void RemoveSelected()
        {
            _SuppressCollectionChanged = true;

            var itemsToRemove = this.Where(x => x.Selected).ToList();

            foreach (var i in itemsToRemove)
            {
                this.Remove(i);
            }

            _SuppressCollectionChanged = false;


            //OnCollectionChangedMultiItem(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new List<T>(itemsToRemove)));

            foreach (var removedItem in itemsToRemove)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removedItem));
            }
        }

        public bool MoveUp(T item)
        {
            int oldIndex = this.IndexOf(item);
            if (oldIndex - 1 < 0)
            {
                return false;
            }
            this.Move(oldIndex, oldIndex - 1);
            item.Selected = true;
            return true;
        }

        public bool MoveDown(T item)
        {
            int oldIndex = this.IndexOf(item);
            if (oldIndex + 1 >= this.Count)
            {
                return false;
            }
            this.Move(oldIndex, oldIndex+1);
            item.Selected = true;
            return true;
        }
    }
}
