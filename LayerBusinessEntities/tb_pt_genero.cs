using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_genero
{ 

   private String _generoid; 
   public String generoid{ 
       get { return _generoid; }

       set { _generoid = value; }
   }

   private String _generoname; 
   public String generoname{ 
       get { return _generoname; }

       set { _generoname = value; }
   }

   private String _generodescort;
   public String generodescort
   {
       get { return _generodescort; }

       set { _generodescort = value; }
   }

   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
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