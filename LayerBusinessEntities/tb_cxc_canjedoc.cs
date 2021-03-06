﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Xml;


namespace LayerBusinessEntities
{
    public class tb_cxc_canjedoc
    {
        // CANJEDOC_CAB
        public String tipcanje { get; set; }
        public String sercanje { get; set; }
        public String numcanje { get; set; }
        public String ctacte { get; set; }
        public DateTime? fechcanje { get; set; }
        public Decimal impocanje { get; set; }
        public String status { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }
        public String Idx { get; set; }

        // CANJEDOC_DET
        public class Item
        {
            public String tipcanje { get; set; }
            public String sercanje { get; set; }
            public String numcanje { get; set; }
            public String tipdoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }
            public Decimal imposaldo { get; set; }
            public String usuar { get; set; }
            public DateTime? fecre { get; set; }
            public DateTime? feact { get; set; }
        }

        public List<Item> ListaItems { get; set; }

        public string GetItemXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (Item obj in ListaItems)
            {
                objNode = objXMLDoc.CreateElement("Item");

                //XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("item"); attrib1.Value = obj.item;
                //XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("cxcaccionid"); attrib2.Value = obj.cxcaccionid;
                //XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("tiprecibo"); attrib3.Value = obj.tiprecibo;
                //XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("serrecibo"); attrib4.Value = obj.serrecibo;
                //XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("numrecibo"); attrib5.Value = obj.numrecibo;
                //XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("fechrecibo"); attrib6.Value = obj.fechrecibo.ToString();
                //XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("fechcobro"); attrib7.Value = obj.fechcobro.ToString();
                //XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("importe"); attrib8.Value = obj.importe.ToString();
                //XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("observacion"); attrib9.Value = obj.observacion.ToString();
                //XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("siturecibo"); attrib10.Value = obj.siturecibo.ToString();
                //XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib11.Value = obj.usuar.ToString();

                //objNode.Attributes.Append(attrib1);
                //objNode.Attributes.Append(attrib2);
                //objNode.Attributes.Append(attrib3);
                //objNode.Attributes.Append(attrib4);
                //objNode.Attributes.Append(attrib5);
                //objNode.Attributes.Append(attrib6);
                //objNode.Attributes.Append(attrib7);
                //objNode.Attributes.Append(attrib8);
                //objNode.Attributes.Append(attrib9);
                //objNode.Attributes.Append(attrib10);
                //objNode.Attributes.Append(attrib11);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

    }
}
