//Project Name: SarreSports | File Name: NullItem.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 8/1/2019 | 18:19
//Last Updated On:  11/1/2019 | 01:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarreSports
{
    class NullItem : IItem
    {
        //Disable Null Reference Instance Warning which occurs as the instance only occurs in null call instances not allowed in runtime
        #pragma warning disable 649
        private static NullItem _instance;
        #pragma warning restore 649

        public NullItem()
        {
        }

        //Static NullItem Instance that may be called as comparable to Item through IItem interface
        public static NullItem Instance  
        {  
            get {  
                if (_instance == null)  
                    return new NullItem();  
                return _instance;  
            }  
        }
    }
}
