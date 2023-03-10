import React from "react";
import { connect } from "react-redux";
import { fetchBreakfastHash } from "./sesionAPI";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import TextField from "@mui/material/TextField";
import styles from "./Sesion.module.css";

class Sesion extends React.Component {
  constructor(props) {
    super(props);
    this.state = { inputValue: "" };
  }

  handleInputChange(event) {
    this.setState({ inputValue: event.target.value });
  }

  onCreateSesion(hash) {
    if (hash !== "") {
      this.props.fetchBreakfastHash(hash);
    }
  }

  render() {
    const { status } = this.props;

    return (
      <div>
        {/* {status === "Error Not Found" ? (
          <h5 className={styles.error}>Breakfast not Found!</h5>
        ) : null}
        {status === "Completed" ? (
          <h5 className={styles.good}>Breakfast Found!!</h5>
        ) : null}
        <label htmlFor="my-input">Write the Code of the Breakfast:</label>
        <br></br>
        <input
          type="number"
          id="my-input"
          value={this.state.inputValue}
          onChange={(event) => this.handleInputChange(event)}
        />
        <p>You typed: {this.state.inputValue}</p>
        <button onClick={() => this.onCreateSesion(this.state.inputValue)}>
          Search the breakfast
        </button> */}
        <Card sx={{ minWidth: 275 }}>
          <CardContent>
            {status === "Error Not Found" ? (
              <h5 className={styles.error}>Breakfast not Found!</h5>
            ) : null}
            {status === "Completed" ? (
              <h5 className={styles.good}>Breakfast Found!!</h5>
            ) : null}
            <Typography sx={{ fontSize: 25 }} color="text.primary" gutterBottom>
              Write the Code of the Breakfast:
            </Typography>
            <TextField
              type="number"
              id="my-input"
              value={this.state.inputValue}
              onChange={(event) => this.handleInputChange(event)}
              label="Breakfast Hash"
              variant="outlined"
            />
          </CardContent>
          <CardActions sx={{ justifyContent: 'center', marginBottom: '10px' }}>
            <Button
              onClick={() => this.onCreateSesion(this.state.inputValue)}
              variant="contained"
              color="primary"
              size="small"
            >
              Search the breakfast
            </Button>
          </CardActions>
        </Card>
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  breakfast: state.sesion.breakfast,
  status: state.sesion.statusSesion,
});

const mapDispatchToProps = {
  fetchBreakfastHash,
};

export default connect(mapStateToProps, mapDispatchToProps)(Sesion);
