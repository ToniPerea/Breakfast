import React from "react";
import logo from "./desayuno.png";
import breakfastLottie from "./breakfast-lottie.json"
import { Counter } from "./features/counter/Counter";
import Sesion from "./features/sesion/Sesion";
import Breakfast from "./features/breakfast/Breakfast";
import List from "./features/list/List";
import Grid from "@mui/material/Grid";
import { Player, Controls } from "@lottiefiles/react-lottie-player";
import "./App.css";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";

const darkTheme = createTheme({
  palette: {
    mode: "dark",
  },
});

function App() {
  return (
    <div className="App">
      <ThemeProvider theme={darkTheme}>
        <CssBaseline />
        <header className="App-header">
          {/* <img src={logo} className="App-logo" alt="logo" /> */}
          <Player
            autoplay
            loop
            src={breakfastLottie}
            style={{ height: "450px", width: "450px" }}
          ></Player>

          {/* <Counter /> */}
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <Sesion />
              <Breakfast />
            </Grid>
            <Grid item xs={6}>
              <List />
            </Grid>
          </Grid>
        </header>
      </ThemeProvider>
    </div>
  );
}

export default App;
