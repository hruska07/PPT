/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

/**
 *Třída pro práci s adresami
 * @author cink01
 * @version 1.2
 */
public class Adresa {
    private String ulice;
    private String mesto;
    private Integer cPop;
    private Integer PSC;

    /**
     * 
     * @param ulice název ulice 
     * @param mesto název města
     * @param cPop číslo popisné
     * @param PSC poštovní smerovací číslo 
     */
    public Adresa(String ulice, String mesto, Integer cPop, Integer PSC) {
        this.ulice = ulice;
        this.mesto = mesto;
        this.cPop = cPop;
        this.PSC = PSC;
    }
    
    /**
     * 
     * 
     * @return String název ulice
     * 
     */
    public String getUlice() { return this.ulice; }
    /**
     * 
     * @return String název města
     */
    public String getMesto() { return this.mesto; }
    /**
     * 
     * @return Integer číslo popisné
     */
    public Integer getCPop() { return this.cPop; }
    /**
     * 
     * @return Integer poštovní směrovací číslo 
     */
    public Integer getPSC() { return this.PSC; } 
    /**
     * Nastaví název ulice
     * @param ulice název ulice    
     */
    public void setUlice(String ulice) { this.ulice = ulice; }
    
    /**
     * Nastaví název města
     * @param mesto název města 
     */
    public void setMesto(String mesto) { this.mesto = mesto; }
    /**
     * Nastaví číslo popisné
     * @param cPop číslo popisné 
     */
    public void setCPop(Integer cPop) { this.cPop = cPop; }
    /**
     * Nastaví poštovní směrovací číslo
     * @param PSC poštovní směrovací číslo 
     */

    public void setPSC(Integer PSC) { this.PSC = PSC; }
    
    /**
     * 
     * @return String  řetězec všech proměnných v třídě    
     */
    @Override
    public String toString() {
        return "Adresa{" + "ulice=" + ulice + ", mesto=" + mesto + ", cPop=" + cPop + ", PSC=" + PSC + '}';
    }
}