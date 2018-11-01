/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

/**
 * Třída pro práci se sazbou
 * @author cink01
 * @version 1.2
 */
public class Sazba {
    private String zkratka;
    private Double hodnota;

    /**
     * 
     * @param zkratka zkratka sazby 
     * @param hodnota hodnota sazby  
     */
    public Sazba(String zkratka, Double hodnota) {
        this.zkratka = zkratka;
        this.hodnota = hodnota;
    }

    /**
     * 
     * @return String zkratka 
     */
    public String getZkratka() {
        return zkratka;
    }

    /**
     * Zadání zkratky sazby
     * @param zkratka zkratka sazby 
     */
    public void setZkratka(String zkratka) {
        this.zkratka = zkratka;
    }

    /**
     * 
     * @return Double hodnota sazby 
     */
    public Double getHodnota() {
        return hodnota;
    }

    /**
     * Zadání hodnoty sazby
     * @param hodnota hodnota sazby 
     */
    public void setHodnota(Double hodnota) {
        this.hodnota = hodnota;
    }

    /**
     * 
     * @return String všechny proměnné v třídě  
     */
    @Override
    public String toString() {
        return "Sazba{" + "zkratka: " + zkratka + ", hodnota = " + (hodnota*100) + "%}";
    }
}