﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_cuota_tiendacargoBL
    {
        tb_me_cuota_tiendacargoDA tablaDA = new tb_me_cuota_tiendacargoDA();

        public bool Insert(string empresaid, tb_me_cuota_tiendacargo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Insert2(string empresaid, tb_me_cuota_tiendacargo BE)
        {
            return tablaDA.Insert2(empresaid, BE);
        }

        public bool Update(string empresaid, tb_me_cuota_tiendacargo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_me_cuota_tiendacargo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_cuota_tiendacargo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll2(string empresaid, tb_me_cuota_tiendacargo BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }     

        public DataSet GetOne(string empresaid, string ubigeoid)
        {
            return tablaDA.GetOne(empresaid, ubigeoid);
        }

    }
}
