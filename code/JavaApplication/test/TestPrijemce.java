/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import javaapplication.Adresa;
import javaapplication.Prijemce;
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
public class TestPrijemce {
    
    public TestPrijemce() {
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
        String test = "Prijemce{jmeno=Jáchym, prijmeni=Hruška, adresa=Adresa{ulice=Tolstého, mesto=Jihlava, cPop=16, PSC=58601}, telefon=123456789, email=example@example.com}";
        String test2 = prijemce1.toString();
        assertEquals(test, test2);
    }
}
