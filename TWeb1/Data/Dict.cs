using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWeb1
{
    static public class Dict
    {
        
        #region dApp
        private static dAppItem _dApp;
        public static dAppItem dApp
        {
            get
            {
                var app = _dApp;
                return app;
            }
            set
            {
                _dApp = value;
            }
        }

        #endregion
        #region ListComplexity

        private static List<DictItem> _listComplexity;
        public static List<DictItem> ListComplexity
        {
            get
            {
                var lst = _listComplexity;
                if (lst == null)
                {
                    using (DBLab1Context db = new DBLab1Context()) { 
                        lst = db.Complexities.Select(a => new DictItem { ID = a.ComplexityId, Name = a.Name }).ToList();
                        _listComplexity = lst;
                    }
                    
                }
                return (List<DictItem>)lst;
            }
            set
            {
                _listComplexity = value;
            }
        }
        #endregion
        #region ListType

        private static List<DictItem> _listType;
        public static List<DictItem> ListType
        {
            get
            {
                var lst = _listType;
                if (lst == null)
                {
                    using (DBLab1Context db = new DBLab1Context())
                    {
                        lst = db.Types.Select(a => new DictItem { ID = a.TypeId, Name = a.Name }).ToList();
                        _listType = lst;
                    }

                }
                return (List<DictItem>)lst;
            }
            set
            {
                _listType = value;
            }
        }
        #endregion
        #region ListSexes
        private static List<DictItem> _listSexes;
        public static List<DictItem> ListSexes
        {
            get
            {
                var lst = _listSexes;
                if (lst == null)
                {
                    using(DBLab1Context db =  new DBLab1Context())
                    {
                        lst = db.Sexes.Select(a => new DictItem { ID = a.SexId, Name = a.Name }).ToList();
                        _listSexes = lst;
                    }
                    
                }
                return lst;
            }
            set
            {
                _listSexes = value;
            }
        }
        #endregion
        #region ListRanks
        private static List<DictItem> _listRanks;
        public static List<DictItem> ListRanks
        {
            get
            {
                var lst = _listRanks;
                if (lst == null)
                {
                    using(DBLab1Context db = new DBLab1Context())
                    {
                        lst = db.Ranks.Select(a => new DictItem { ID = a.RankId, Name = a.Name }).ToList();
                        _listRanks = lst;
                    }
                
                }
                return lst;
            }
            set
            {
                _listRanks = value;
            }
        }
        #endregion
        #region ListAdmitions
        private static List<DictItem> _listAdmitions;
        public static List<DictItem> ListAdmitions
        {
            get
            {
                var lst = _listAdmitions;
                if (lst == null)
                {
                    using(DBLab1Context db = new DBLab1Context())
                    {
                        lst = db.Admitions.Select(a => new DictItem { ID = a.AdmittedId, Name = a.Name }).ToList();
                        _listAdmitions = lst;
                    }
                    
                }
                return lst;
            }
            set
            {
                _listAdmitions = value;
            }
        }
        #endregion
        #region ListRoles
        private static List<DictItem> _listRoles;
        public static List<DictItem> ListRoles
        {
            get
            {
                var lst = _listRoles;
                if (lst == null)
                {
                    using (DBLab1Context db = new DBLab1Context())
                    {
                        lst = db.Roles.Select(a => new DictItem { ID = a.RolesId, Name = a.Name }).ToList();
                        _listRoles = lst;
                    }

                }
                return lst;
            }
            set
            {
                _listRoles = value;
            }
        }
        #endregion
    }
}
