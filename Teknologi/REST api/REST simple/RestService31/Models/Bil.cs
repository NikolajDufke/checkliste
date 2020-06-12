using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestService31.Models
{
    public class Bil
    {
        //model klasse brug "propfull" for props og instance fields
        //husk en "ctorf" når du har lavet alle props
        //husk også "ctor"

        private string _mærke;
        private int _id;

        public Bil()
        {

        }

        public Bil(string mærke, int id)
        {
            _mærke = mærke;
            _id = id;
        }

        //brug key hvis det skal være inmemory
        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Mærke
        {
            get { return _mærke; }
            set { _mærke = value; }
        }
    }
}
