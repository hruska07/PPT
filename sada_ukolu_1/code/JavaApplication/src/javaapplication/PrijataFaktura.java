/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

import java.util.Date;
import java.util.List;

/**
 *Třída pro práci s přijatými fakturami
 * @author fotov
 * @version 1.2
 */

public class PrijataFaktura extends Faktura {

    public PrijataFaktura(Integer cDokladu, Date datumVyst, Date datumSplat, Prijemce prijemce, List<Polozka> polozka, String poznamka, Symbol symbol) {
        super(cDokladu, datumVyst, datumSplat, prijemce, polozka, poznamka, symbol);
    }


   
   

   
    /**
     * 
     * @return Double celkem
     */

    @Override
    public Double getCelkem() {
        return 0.0;// getPolozka().getCena().getSDPH() * (-1);
    }
    
}
