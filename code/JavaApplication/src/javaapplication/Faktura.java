/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;
import java.util.Date;
import java.util.List;

/**
 * Třída pro práci s fakturami
 * @author cink01
 * @version 1.2
 */

abstract public class Faktura{

    private Integer cDokladu;
    private Date datumVyst;
    private Date datumSplat;
    private Prijemce prijemce;
    private List<Polozka> polozka;
    private String poznamka;
    private Symbol symbol;

    
          
    /**
     * 
     * @param cDokladu číslo dokladu
     * @param datumVyst datum vystavení
     * @param datumSplat datum splatnosti
     * @param prijemce příjemce
     * @param cena cena  
     * @param poznamka poznamka 
     * @param Symbol symbol
    */


    public Faktura(Integer cDokladu, Date datumVyst, Date datumSplat, Prijemce prijemce, List<Polozka> polozka, String poznamka, Symbol symbol) {
        this.cDokladu = cDokladu;
        this.datumVyst = datumVyst;
        this.datumSplat = datumSplat;
        this.prijemce = prijemce;
        this.polozka = polozka;
        this.poznamka = poznamka;
        this.symbol = symbol;
    }

    public Symbol getSymbol() {
        return symbol;
    }

    public void setSymbol(Symbol symbol) {
        this.symbol = symbol;
    }

   

    public Integer getcDokladu() {
        return cDokladu;
    }

    public void setcDokladu(Integer cDokladu) {
        this.cDokladu = cDokladu;
    }

    public String getPoznamka() {
        return poznamka;
    }

    public void setPoznamka(String poznamka) {
        this.poznamka = poznamka;
    }

    
    
    public abstract Double getCelkem();
    
    /**
     * 
     * @return Integer číslo dokladu 
     */
    public Integer getCDokladu() {
        return cDokladu;
    }

    /**
     * Zadání čísla dokladu
     * @param cDokladu číslo dokladu 
     */
    public void setCDokladu(Integer cDokladu) {
        this.cDokladu = cDokladu;
    }
    
    /**
     * 
     * @return Date datum vystavení  
     */
    public Date getDatumVyst() {
        return datumVyst;
    }

    /**
     * Zadání datumu vystavení
     * @param datumVyst datum vystavení
     */
    public void setDatumVyst(Date datumVyst) {
        this.datumVyst = datumVyst;
    }

    /**
     * 
     * @return Date datum splatnosti 
     */
    public Date getDatumSplat() {
        return datumSplat;
    }

    /**
     * Zadání datumu splatnosti
     * @param datumSplat datum splatnosti 
     */
    public void setDatumSplat(Date datumSplat) {
        this.datumSplat = datumSplat;
    }

    /**
     * 
     * @return Prijemce příjemce 
     */
    public Prijemce getPrijemce() {
        return prijemce;
    }

    /**
     * Zadání příjemce
     * @param prijemce jmeno příjemce   
     */
    public void setPrijemce(Prijemce prijemce) {
        this.prijemce = prijemce;
    }
 
    public List<Polozka> getPolozka() {
        return polozka;
    }  

    /**
     *
     * @return Cena cena 
     */
    public void setPolozka(List<Polozka> polozka) {
        this.polozka = polozka;
    }

    @Override
    public String toString() {
        return "Faktura{" + "cDokladu=" + cDokladu + ", datumVyst=" + datumVyst + ", datumSplat=" + datumSplat + ", prijemce=" + prijemce + ", polozka=" + polozka + ", poznamka=" + poznamka + ", symbol=" + symbol + '}';
    }

    /**
     *
     * @return String všechny proměnné v třídě
     */ 
 
}