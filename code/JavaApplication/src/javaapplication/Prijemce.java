/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication;

/**
 *Třída pro práci s příjemcem faktury
 * @author cink01
 * @version 1.2
 */
public class Prijemce {
    private String jmeno;
    private String prijmeni;
    private Adresa adresa;
    private String telefon;
    private String email;

    /**
     * 
     * @param jmeno jméno příjemce
     * @param prijmeni příjmení příjemce
     * @param adresa adresa příjemce
     * @param telefon telefon příjemce
     * @param email email příjemce
     */
    public Prijemce(String jmeno, String prijmeni, Adresa adresa, String telefon, String email) {
        this.jmeno = jmeno;
        this.prijmeni = prijmeni;
        this.adresa = adresa;
        this.telefon = telefon;
        this.email = email;
    }

    /**
     * 
     * @return String jmeno příjemce 
     */
    public String getJmeno() {
        return jmeno;
    }

    /**
     * Zadání jména příjemce
     * @param jmeno jméno příjemce 
     */
    public void setJmeno(String jmeno) {
        this.jmeno = jmeno;
    }

    /**
     * 
     * @return String příjmení příjemce 
     */
    public String getPrijmeni() {
        return prijmeni;
    }

    /**
     *Zadání příjmení příjemce 
     * @param prijmeni příjmení příjemce 
     */
    public void setPrijmeni(String prijmeni) {
        this.prijmeni = prijmeni;
    }

    /**
     * 
     * @return Object adresa  
     */
    public Object getAdresa() {
        return adresa;
    }

    /**
     * Zadání adresy
     * @param adresa adresa   
     */
    public void setAdresa(Adresa adresa) {
        this.adresa = adresa;
    }

    /**
     * 
     * @return String telefonní číslo 
     */
    public String getTelefon() {
        return telefon;
    }

    /**
     * Zadání telefonního čísla
     * @param telefon telefonní číslo 
     */
    public void setTelefon(String telefon) {
        this.telefon = telefon;
    }

    /**
     * 
     * @return String email 
     */
    public String getEmail() {
        return email;
    }

    /**
     * Zadání emailu
     * @param email email 
     */
    public void setEmail(String email) {
        this.email = email;
    }

    /**
     * 
     * @return String všechny proměnné v třídě   
     */
    @Override
    public String toString() {
        return "Prijemce{" + "jmeno=" + jmeno + ", prijmeni=" + prijmeni + ", adresa=" + adresa + ", telefon=" + telefon + ", email=" + email + '}';
    }
}