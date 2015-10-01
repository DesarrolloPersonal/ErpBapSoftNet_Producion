﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_ta_estructuraBL
    {
        tb_ta_estructuraDA tablaDA = new tb_ta_estructuraDA();

        public bool Insert(string empresaid, tb_ta_estructura BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_ta_estructura BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_ta_estructura BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_ta_estructura BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_ta_estructura BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }        
        public DataSet GetOne(string empresaid, string estructuraid)
        {
            return tablaDA.GetOne(empresaid, estructuraid);
        }
    }
}
