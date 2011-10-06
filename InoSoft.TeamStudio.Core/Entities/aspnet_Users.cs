//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace InoSoft.TeamStudio.Core.Entities
{
    public partial class aspnet_Users
    {
        #region Primitive Properties
    
        public virtual System.Guid ApplicationId
        {
            get;
            set;
        }
    
        public virtual System.Guid UserId
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }
    
        public virtual string LoweredUserName
        {
            get;
            set;
        }
    
        public virtual string MobileAlias
        {
            get;
            set;
        }
    
        public virtual bool IsAnonymous
        {
            get;
            set;
        }
    
        public virtual System.DateTime LastActivityDate
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<User> Users
        {
            get
            {
                if (_users == null)
                {
                    var newCollection = new FixupCollection<User>();
                    newCollection.CollectionChanged += FixupUsers;
                    _users = newCollection;
                }
                return _users;
            }
            set
            {
                if (!ReferenceEquals(_users, value))
                {
                    var previousValue = _users as FixupCollection<User>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUsers;
                    }
                    _users = value;
                    var newValue = value as FixupCollection<User>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUsers;
                    }
                }
            }
        }
        private ICollection<User> _users;

        #endregion
        #region Association Fixup
    
        private void FixupUsers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (User item in e.NewItems)
                {
                    item.aspnet_Users = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (User item in e.OldItems)
                {
                    if (ReferenceEquals(item.aspnet_Users, this))
                    {
                        item.aspnet_Users = null;
                    }
                }
            }
        }

        #endregion
    }
}
