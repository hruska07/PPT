/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

/**
 *
 * @author fotov
 */
public class Symbol {
    private String variabilni;    
    private String konstatni;    
    private String specificky;    

    public Symbol(String variabilni, String konstatni, String specificky) {
        this.variabilni = variabilni;
        this.konstatni = konstatni;
        this.specificky = specificky;
    }

    public String getVariabilni() {
        return variabilni;
    }

    public void setVariabilni(String variabilni) {
        this.variabilni = variabilni;
    }

    public String getKonstatni() {
        return konstatni;
    }

    public void setKonstatni(String konstatni) {
        this.konstatni = konstatni;
    }

    public String getSpecificky() {
        return specificky;
    }

    public void setSpecificky(String specificky) {
        this.specificky = specificky;
    }

    @Override
    public String toString() {
        return "Symbol{" + "variabilni=" + variabilni + ", konstatni=" + konstatni + ", specificky=" + specificky + '}';
    }
}


