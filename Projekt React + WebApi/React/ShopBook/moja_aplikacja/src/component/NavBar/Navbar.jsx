import React from 'react'
import { AppBar, Toolbar,IconButton, Badge, MenuItem, Menu, Typography} from '@material-ui/core';
import {CallMissedSharp, ShoppingCart} from '@material-ui/icons';
import { mergeClasses } from '@material-ui/styles';
import logo from './assets/ikona.png';
import useStyles from './styles';

const Navbar = () => {
    const classes = useStyles();
    
  return (
    <>
    <AppBar position='fixed' className={classes.appBar} color='inherit'>
        <Toolbar>
            <Typography>
                <img src={logo} alt ='Commerce.js' height ='25px' className={classes.image}></img>
                Commerce.js
            </Typography>
            <div className={classes.grow}/>
            <div className={classes.button}>
                <IconButton aria-label='Pokaz karty przedmiotu' color = 'inherit'>
                    <Badge badgeContent={2} color="secondary">
                    <ShoppingCart/>
                    </Badge>
                </IconButton>
            </div>
        </Toolbar>
    </AppBar>
    </>
  )
}

export default Navbar