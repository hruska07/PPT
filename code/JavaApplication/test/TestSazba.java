/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import javaapplication.Adresa;
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
public class TestSazba {
    
    public TestSazba() {
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
        String test = "Sazba{zkratka: STR, hodnota = 15.0%}";
        String test2 = sazba1.toString();
        assertEquals(test, test2);
    }
}
