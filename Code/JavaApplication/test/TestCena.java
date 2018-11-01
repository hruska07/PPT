/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import javaapplication.Adresa;
import javaapplication.Cena;
import javaapplication.Sazba;
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
public class TestCena {
    
    public TestCena() {
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
        Sazba sazba1 = new Sazba("STR", 0.15);
        Cena cena1 = new Cena(1500.50, sazba1);
        String test = "Cena{bDPH=1500.5Kč, sDPH=1725.575Kč, sazba=Sazba{zkratka: STR, hodnota = 15.0%}}";
        String test2 = cena1.toString();
        assertEquals(test, test2);
    }
}
