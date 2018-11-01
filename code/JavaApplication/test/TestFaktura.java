/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import javaapplication.Adresa;
import javaapplication.Cena;
import javaapplication.Faktura;
import javaapplication.PrijataFaktura;
import javaapplication.Prijemce;
import javaapplication.Sazba;
import javaapplication.Symbol;
import javaapplication.VydanaFaktura;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author hruska07
 */
public class TestFaktura {
    
    public TestFaktura() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    // TODO add test methods here.
    // The methods must be annotated with annotation @Test. For example:
    //
    // @Test
    // public void hello() {}
    
    @Test
    public void testToString() 
    {
        Adresa adresa1 = new Adresa("Tolstého", "Jihlava", 16, 58601);
        Prijemce prijemce1 = new Prijemce("Jáchym", "Hruška", adresa1, "123456789", "example@example.com");
        Sazba sazba1 = new Sazba("STR", 0.15);
        Cena cena1 = new Cena(1500.50, sazba1);
             Symbol symbol = new Symbol("100", "200", "300");
        VydanaFaktura faktura1 = new VydanaFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce1, cena1,"", symbol);
        String test = "Faktura{cDokladu=1, datumVyst=Mon Nov 04 18:43:00 CET 3918, datumSplat=Mon Nov 04 18:43:00 CET 3918, prijemce=Prijemce{jmeno=Jáchym, prijmeni=Hruška, adresa=Adresa{ulice=Tolstého, mesto=Jihlava, cPop=16, PSC=58601}, telefon=123456789, email=example@example.com}, cena=Cena{bDPH=1500.5Kč, sDPH=1725.575Kč, sazba=Sazba{zkratka: STR, hodnota = 15.0%}}, poznamka=, symbol=Symbol{variabilni=100, konstatni=200, specificky=300}}";
        String test2 = faktura1.toString();
        assertEquals(test, test2);
    }
    
    @Test
    public void test2ToString() 
    {
         Adresa adresa2 = new Adresa("Citrusova", "Jablko", 2, 15856);
        Prijemce prijemce2 = new Prijemce("Vít", "Bobánek", adresa2, "123456789", "example@example.com");
        Sazba sazba2 = new Sazba("DVCT", 0.20);
        Cena cena2 = new Cena(25000.55, sazba2);
        Symbol symbol = new Symbol("100", "200", "300");
        PrijataFaktura faktura1 = new PrijataFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce2, cena2,"", symbol);
        String test = "Faktura{cDokladu=1, datumVyst=Mon Nov 04 18:43:00 CET 3918, datumSplat=Mon Nov 04 18:43:00 CET 3918, prijemce=Prijemce{jmeno=Vít, prijmeni=Bobánek, adresa=Adresa{ulice=Citrusova, mesto=Jablko, cPop=2, PSC=15856}, telefon=123456789, email=example@example.com}, cena=Cena{bDPH=25000.55Kč, sDPH=30000.66Kč, sazba=Sazba{zkratka: DVCT, hodnota = 20.0%}}, poznamka=, symbol=Symbol{variabilni=100, konstatni=200, specificky=300}}";
        String test2 = faktura1.toString();
        assertEquals(test, test2);
    }
    
    @Test
    public void testGetCelkem(){
         Adresa adresa1 = new Adresa("Tolstého", "Jihlava", 16, 58601);
        Prijemce prijemce1 = new Prijemce("Jáchym", "Hruška", adresa1, "123456789", "example@example.com");
        Sazba sazba1 = new Sazba("STR", 0.15);
        Cena cena1 = new Cena(1500.50, sazba1);
        Adresa adresa2 = new Adresa("Citrusova", "Jablko", 2, 15856);
        Prijemce prijemce2 = new Prijemce("Vít", "Bobánek", adresa2, "123456789", "example@example.com");
        Sazba sazba2 = new Sazba("DVCT", 0.20);
        Cena cena2 = new Cena(25000.55, sazba2);
        Symbol symbol = new Symbol("100", "200", "300");
      //  Faktura faktura1 = new Faktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce1, cena1) {};
        Map<String, List<Faktura>> SeznamFaktur = new HashMap<String, List<Faktura>>();
        List<Faktura> seznamvydanych;  
        List<Faktura> seznamprijatych; 
        seznamprijatych = new LinkedList();
        seznamvydanych = new LinkedList();
      
        VydanaFaktura fakturaV1 = new VydanaFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce1, cena1, "", symbol) {};
        VydanaFaktura fakturaV2 = new VydanaFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce1, cena1, "", symbol) {};
        VydanaFaktura fakturaV3 = new VydanaFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce1, cena1, "", symbol) {};
        PrijataFaktura fakturaP1 = new PrijataFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce2, cena2, "", symbol) {};
        PrijataFaktura fakturaP2 = new PrijataFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce2, cena2, "", symbol) {};
        PrijataFaktura fakturaP3 = new PrijataFaktura(1, new Date(2018, 10,4,18,43,00), new Date(2018, 10,4,18,43,00), prijemce2, cena2, "", symbol) {};
        seznamvydanych.add(fakturaV1);
        seznamvydanych.add(fakturaV2);
        seznamvydanych.add(fakturaV3);
        seznamprijatych.add(fakturaP1);
        seznamprijatych.add(fakturaP2);
        seznamprijatych.add(fakturaP3);
        SeznamFaktur.put("P:", seznamprijatych);
        SeznamFaktur.put("V:", seznamvydanych);
        
        Double cena = 0.00;
        for (List<Faktura> it : SeznamFaktur.values()) {
            for (Faktura it2 : it)
            {
                cena += it2.getCelkem();
            }
        }
        Double cenaTest = -84825.255;
        assertEquals(cena, cenaTest);
    }
}
