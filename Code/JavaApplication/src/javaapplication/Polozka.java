/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

/**
 *
 * @author cink01
 */
public class Polozka {
    private String nazev_p;
    private Integer pocet_p;
    private Cena cena_p;
    
    public Polozka(String nazev_p, Integer pocet_p, Cena cena_p) {
        this.nazev_p = nazev_p;
        this.pocet_p = pocet_p;
        this.cena_p = cena_p;
    }

    public String getNazev_p() {
        return nazev_p;
    }

    public void setNazev_p(String nazev_p) {
        this.nazev_p = nazev_p;
    }

    public Cena getCena_p() {
        return cena_p;
    }

    public void setCena_p(Cena cena_p) {
        this.cena_p = cena_p;
    }

    public Integer getPocet_p() {
        return pocet_p;
    }

    public void setPocet_p(Integer pocet_p) {
        this.pocet_p = pocet_p;
    }

    @Override
    public String toString() {
        return "Polozka{" + "nazev_p=" + nazev_p + ", pocet_p=" + pocet_p + ", cena_p=" + cena_p + '}';
    }



    
}
