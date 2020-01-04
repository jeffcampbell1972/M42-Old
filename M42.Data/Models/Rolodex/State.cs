using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("States", Schema = "Rolodex")]
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string ISOCode { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        private static List<State> values;
        public static List<State> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<State>() {
                        AL,
                        AK,
                        AZ,
                        AR,
                        CA,
                        CO,
                        CT,
                        DE,
                        FL,
                        GA,
                        HI,
                        ID,
                        IL,
                        IN,
                        IA,
                        KS,
                        KY,
                        LA,
                        ME,
                        MD,
                        MA,
                        MI,
                        MN,
                        MS,
                        MO,
                        MT,
                        NE,
                        NV,
                        NH,
                        NJ,
                        NM,
                        NY,
                        NC,
                        ND,
                        OH,
                        OK,
                        OR,
                        PA,
                        RI,
                        SC,
                        SD,
                        TN,
                        TX,
                        UT,
                        VT,
                        VA,
                        WA,
                        WV,
                        WI,
                        WY,
                        DC
                    };
                }
                return values;
            }
        }

        static private State al;
        static private State ak;
        static private State az;
        static private State ar;
        static private State ca;
        static private State co;
        static private State ct;
        static private State de;
        static private State fl;
        static private State ga;
        static private State hi;
        static private State id;
        static private State il;
        static private State ind;
        static private State ia;
        static private State ks;
        static private State ky;
        static private State la;
        static private State me;
        static private State md;
        static private State ma;
        static private State mi;
        static private State mn;
        static private State ms;
        static private State mo;
        static private State mt;
        static private State ne;
        static private State nv;
        static private State nh;
        static private State nj;
        static private State nm;
        static private State ny;
        static private State nc;
        static private State nd;
        static private State oh;
        static private State ok;
        static private State or;
        static private State pa;
        static private State ri;
        static private State sc;
        static private State sd;
        static private State tn;
        static private State tx;
        static private State ut;
        static private State vt;
        static private State va;
        static private State wa;
        static private State wv;
        static private State wi;
        static private State wy;
        static private State dc;

        static public State AL { get { return al ?? (al = new State { Id = 1, Name = "Alabama", Abbreviation = "AL", ISOCode = "US-AL", CountryId = Country.US.Id }); } }
        static public State AK { get { return ak ?? (ak = new State { Id = 2, Name = "Alaska", Abbreviation = "AK", ISOCode = "US-AK", CountryId = Country.US.Id  }); } }
        static public State AZ { get { return az ?? (az = new State { Id = 3, Name = "Arizona", Abbreviation = "AZ", ISOCode = "US-AZ", CountryId = Country.US.Id }); } }
        static public State AR { get { return ar ?? (ar = new State { Id = 4, Name = "Arkansas", Abbreviation = "AR", ISOCode = "US-AL", CountryId = Country.US.Id }); } }
        static public State CA { get { return ca ?? (ca = new State { Id = 5, Name = "California", Abbreviation = "CA", ISOCode = "US-CA", CountryId = Country.US.Id }); } }
        static public State CO { get { return co ?? (co = new State { Id = 6, Name = "Colorado", Abbreviation = "CO", ISOCode = "US-CO", CountryId = Country.US.Id }); } }
        static public State CT { get { return ct ?? (ct = new State { Id = 7, Name = "Connecticut", Abbreviation = "CT", ISOCode = "US-CT", CountryId = Country.US.Id }); } }
        static public State DE { get { return de ?? (de = new State { Id = 8, Name = "Deleware", Abbreviation = "DE", ISOCode = "US-DE", CountryId = Country.US.Id }); } }
        static public State FL { get { return fl ?? (fl = new State { Id = 9, Name = "Florida", Abbreviation = "FL", ISOCode = "US-FL", CountryId = Country.US.Id }); } }
        static public State GA { get { return ga ?? (ga = new State { Id = 10, Name = "Georgia", Abbreviation = "GA", ISOCode = "US-GA", CountryId = Country.US.Id }); } }
        static public State HI { get { return hi ?? (hi = new State { Id = 11, Name = "Hawaii", Abbreviation = "HI", ISOCode = "US-HI", CountryId = Country.US.Id }); } }
        static public State ID { get { return id ?? (id = new State { Id = 12, Name = "Idaho", Abbreviation = "ID", ISOCode = "US-ID", CountryId = Country.US.Id }); } }
        static public State IL { get { return il ?? (il = new State { Id = 13, Name = "Illinois", Abbreviation = "IL", ISOCode = "US-IL", CountryId = Country.US.Id }); } }
        static public State IN { get { return ind ?? (ind = new State { Id = 14, Name = "Indiana", Abbreviation = "IN", ISOCode = "US-IN", CountryId = Country.US.Id }); } }
        static public State IA { get { return ia ?? (ia = new State { Id = 15, Name = "Iowa", Abbreviation = "IA", ISOCode = "US-IA", CountryId = Country.US.Id }); } }
        static public State KS { get { return ks ?? (ks = new State { Id = 16, Name = "Kansas", Abbreviation = "KS", ISOCode = "US-KS", CountryId = Country.US.Id }); } }
        static public State KY { get { return ky ?? (ky = new State { Id = 17, Name = "Kentucky", Abbreviation = "KY", ISOCode = "US-KY", CountryId = Country.US.Id }); } }
        static public State LA { get { return la ?? (la = new State { Id = 18, Name = "Louisiana", Abbreviation = "LA", ISOCode = "US-LA", CountryId = Country.US.Id }); } }
        static public State ME { get { return me ?? (me = new State { Id = 19, Name = "Maine", Abbreviation = "ME", ISOCode = "US-ME", CountryId = Country.US.Id }); } }
        static public State MD { get { return md ?? (md = new State { Id = 20, Name = "Maryland", Abbreviation = "MD", ISOCode = "US-MD", CountryId = Country.US.Id }); } }
        static public State MA { get { return ma ?? (ma = new State { Id = 21, Name = "Massachusetts", Abbreviation = "MA", ISOCode = "US-MA", CountryId = Country.US.Id }); } }
        static public State MI { get { return mi ?? (mi = new State { Id = 22, Name = "Michigan", Abbreviation = "MI", ISOCode = "US-MI", CountryId = Country.US.Id }); } }
        static public State MN { get { return mn ?? (mn = new State { Id = 23, Name = "Minnesota", Abbreviation = "MN", ISOCode = "US-MN", CountryId = Country.US.Id }); } }
        static public State MS { get { return ms ?? (ms = new State { Id = 24, Name = "Mississippi", Abbreviation = "MS", ISOCode = "US-MS", CountryId = Country.US.Id }); } }
        static public State MO { get { return mo ?? (mo = new State { Id = 25, Name = "Missouri", Abbreviation = "MO", ISOCode = "US-MO", CountryId = Country.US.Id }); } }
        static public State MT { get { return mt ?? (mt = new State { Id = 26, Name = "Montana", Abbreviation = "MT", ISOCode = "US-MT", CountryId = Country.US.Id }); } }
        static public State NE { get { return ne ?? (ne = new State { Id = 27, Name = "Nebraska", Abbreviation = "NE", ISOCode = "US-NE", CountryId = Country.US.Id }); } }
        static public State NV { get { return nv ?? (nv = new State { Id = 28, Name = "Nevada", Abbreviation = "NV", ISOCode = "US-NV", CountryId = Country.US.Id }); } }
        static public State NH { get { return nh ?? (nh = new State { Id = 29, Name = "New Hampshire", Abbreviation = "NH", ISOCode = "US-NH", CountryId = Country.US.Id }); } }
        static public State NJ { get { return nj ?? (nj = new State { Id = 30, Name = "New Jersey", Abbreviation = "NJ", ISOCode = "US-NJ", CountryId = Country.US.Id }); } }
        static public State NM { get { return nm ?? (nm = new State { Id = 31, Name = "New Mexico", Abbreviation = "NM", ISOCode = "US-NM", CountryId = Country.US.Id }); } }
        static public State NY { get { return ny ?? (ny = new State { Id = 32, Name = "New York", Abbreviation = "NY", ISOCode = "US-NY", CountryId = Country.US.Id }); } }
        static public State NC { get { return nc ?? (nc = new State { Id = 33, Name = "North Carolina", Abbreviation = "NC", ISOCode = "US-NC", CountryId = Country.US.Id }); } }
        static public State ND { get { return nd ?? (nd = new State { Id = 34, Name = "North Dakota", Abbreviation = "ND", ISOCode = "US-ND", CountryId = Country.US.Id }); } }
        static public State OH { get { return oh ?? (oh = new State { Id = 35, Name = "Ohio", Abbreviation = "OH", ISOCode = "US-OH", CountryId = Country.US.Id }); } }
        static public State OK { get { return ok ?? (ok = new State { Id = 36, Name = "Oklahoma", Abbreviation = "OK", ISOCode = "US-OK", CountryId = Country.US.Id }); } }
        static public State OR { get { return or ?? (or = new State { Id = 37, Name = "Oregon", Abbreviation = "OR", ISOCode = "US-OR", CountryId = Country.US.Id }); } }
        static public State PA { get { return pa ?? (pa = new State { Id = 38, Name = "Pennsylvania", Abbreviation = "PA", ISOCode = "US-PA", CountryId = Country.US.Id }); } }
        static public State RI { get { return ri ?? (ri = new State { Id = 39, Name = "Rhode Island", Abbreviation = "RI", ISOCode = "US-RI", CountryId = Country.US.Id }); } }
        static public State SC { get { return sc ?? (sc = new State { Id = 40, Name = "South Carolina", Abbreviation = "SC", ISOCode = "US-SC", CountryId = Country.US.Id }); } }
        static public State SD { get { return sd ?? (sd = new State { Id = 41, Name = "South Dakata", Abbreviation = "SD", ISOCode = "US-SD", CountryId = Country.US.Id }); } }
        static public State TN { get { return tn ?? (tn = new State { Id = 42, Name = "Tennessee", Abbreviation = "TN", ISOCode = "US-TN", CountryId = Country.US.Id }); } }
        static public State TX { get { return tx ?? (tx = new State { Id = 43, Name = "Texas", Abbreviation = "TX", ISOCode = "US-TX", CountryId = Country.US.Id }); } }
        static public State UT { get { return ut ?? (ut = new State { Id = 44, Name = "Utah", Abbreviation = "UT", ISOCode = "US-UT", CountryId = Country.US.Id }); } }
        static public State VT { get { return vt ?? (vt = new State { Id = 45, Name = "Vermont", Abbreviation = "VT", ISOCode = "US-VT", CountryId = Country.US.Id }); } }
        static public State VA { get { return va ?? (va = new State { Id = 46, Name = "Virginia", Abbreviation = "VA", ISOCode = "US-VA", CountryId = Country.US.Id }); } }
        static public State WA { get { return wa ?? (wa = new State { Id = 47, Name = "Washington", Abbreviation = "WA", ISOCode = "US-WA", CountryId = Country.US.Id }); } }
        static public State WV { get { return wv ?? (wv = new State { Id = 48, Name = "West Virginia", Abbreviation = "WV", ISOCode = "US-WV", CountryId = Country.US.Id }); } }
        static public State WI { get { return wi ?? (wi = new State { Id = 49, Name = "Wisconsin", Abbreviation = "WI", ISOCode = "USWIAL", CountryId = Country.US.Id }); } }
        static public State WY { get { return wy ?? (wy = new State { Id = 50, Name = "Wyoming", Abbreviation = "WY", ISOCode = "US-WY", CountryId = Country.US.Id }); } }
        static public State DC { get { return dc ?? (dc = new State { Id = 51, Name = "District of Columbia", Abbreviation = "DC", ISOCode = "US-DC", CountryId = Country.US.Id }); } }

    }
}
