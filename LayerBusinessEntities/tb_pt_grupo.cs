using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_grupo
{ 

   private String _grupoid; 
   public String grupoid{ 
       get { return _grupoid; }

       set { _grupoid = value; }
   }

   private String _gruponame; 
   public String gruponame{ 
       get { return _gruponame; }

       set { _gruponame = value; }
   }

   private String _marcaid;
   public String marcaid
   {
       get { return _marcaid; }
       set { _marcaid = value; }
   }


   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
   }


   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private DateTime? _fecre; 
   public DateTime? fecre{ 
       get { return _fecre; }

       set { _fecre = value; }
   }

   private DateTime? _feact; 
   public DateTime? feact{ 
       get { return _feact; }

       set { _feact = value; }
   }

}
}
