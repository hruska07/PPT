/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

/**
 *Třída pro práci s cenami
 * @author cink01
 * @version 1.2
 */

public class Cena {
    private Double bDPH;
    private Double sDPH;
    private Sazba sazba;
    
/**
 * 
 * @param bDPH cena bez DPH
 * @param sazba sazba
 */
    public Cena(Double bDPH, Sazba sazba) {
        this.bDPH = bDPH;
        prepocetSDPH(bDPH, sazba);
        this.sazba = sazba;
    }

    /**
     * Přepočet ceny na cenu s DPH
     * @param bDPH1 cena bez DPH 
     * @param sazba1 sazba 
     */
    private void prepocetSDPH(Double bDPH1, Sazba sazba1) {
        this.sDPH = bDPH1 + bDPH1 * sazba1.getHodnota();
    }
/**
 * 
 * @return Double cena bez DPH  
 */
    public Double getBDPH() {
        return bDPH;
    }

    /**
     * Zadání ceny bez DPH
     * @param bDPH cena bez DPH 
     */
    public void setBDPH(Double bDPH) {
        this.bDPH = bDPH;
        prepocetSDPH(bDPH, sazba);
    }

    /**
     *
     * @return Double cena s DPH
     */
    public Double getSDPH() {
        return sDPH;
    }
    
    /**
     * 
     * @return Sazba sazba   
     */
    public Sazba getSazba() {
        return sazba;
    }

    /**
     * Nastaví sazbu
     * @param sazba sazba 
     */
    public void setSazba(Sazba sazba) {
            this.sazba = sazba;
    }

    /**
     * 
     * @return String všechny proměnné v třídě  
     */
    @Override
    public String toString() {
        return "Cena{" + "bDPH=" + bDPH + "Kč, sDPH=" + sDPH + "Kč, sazba=" + sazba + '}';
    }
}