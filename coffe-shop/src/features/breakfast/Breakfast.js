import React from "react";
import { connect } from "react-redux";
import { createBreakfast, fetchMealList, fetchDrinkList } from "./breakfastAPI";
import { fetchBreakfastHash } from "../sesion/sesionAPI";
import Autocomplete from "@mui/material/Autocomplete";
import TextField from "@mui/material/TextField";
import Card from "@mui/material/Card";
import Button from "@mui/material/Button";
import CardContent from "@mui/material/CardContent";
import styles from "./Breakfast.module.css";

const delay = (ms) => new Promise((res) => setTimeout(res, ms));

class Breakfast extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      inputMealValue: "",
      inputMealId: "",
      inputDrinkValue: "",
      inputDrinkId: "",
    };
  }

  // onMealSuggestionSelected(suggestion) {
  //   this.setState({
  //     inputMealValue: suggestion.meal,
  //     inputMealId: suggestion.id,
  //   });
  // }

  // onDrinkSuggestionSelected(suggestion) {
  //   this.setState({
  //     inputDrinkValue: suggestion.drink,
  //     inputDrinkId: suggestion.id,
  //   });
  // }

  async onSaveBreakfast() {
    if (
      this.state.inputMealValue !== "" &&
      this.state.inputDrinkValue !== "" &&
      this.props.hashCode
    ) {
      const bodyData = {
        id: "",
        hashCode: this.props.hashCode,
        mealId: this.state.inputMealId,
        drinkId: this.state.inputDrinkId,
      };
      this.props.createBreakfast(bodyData);
      await delay(1000);
      this.props.fetchBreakfastHash(this.props.hashCode);
    }
  }

  componentDidMount() {
    this.props.fetchMealList();
    this.props.fetchDrinkList();
  }

  render() {
    const { mealList } = this.props;
    const { drinkList } = this.props;

    const filteredMealData = mealList.filter((item) => {
      if (this.state.inputMealValue !== null) {
        return item.meal
          .toLowerCase()
          .includes(this.state.inputMealValue.toLowerCase());
      }
      return true;
    });

    const filteredDrinkData = drinkList.filter((item) => {
      return item.drink
        .toLowerCase()
        .includes(this.state.inputDrinkValue.toLowerCase());
    });

    const handleChangeMeal = (event, newValue) => {
      const valueFind = mealList.find((item) => item.meal === newValue);
      if (valueFind) {
        this.setState({ inputMealId: valueFind.id });
        this.setState({ inputMealValue: newValue });
      } else {
        this.setState({ inputMealValue: "" });
        this.setState({ inputMealId: "" });
      }
    };
    const handleChangeDrink = (event, newValue) => {
      const valueFind = drinkList.find((item) => item.drink === newValue);
      if (valueFind) {
        this.setState({ inputDrinkId: valueFind.id });
        this.setState({ inputDrinkValue: newValue });
      } else {
        this.setState({ inputDrinkValue: "" });
        this.setState({ inputDrinkId: "" });
      }
    };

    return (
      <div>
        {/* Meal Search: <br></br>
        <input
          type="text"
          value={this.state.inputMealValue}
          onChange={(event) =>
            this.setState({ inputMealValue: event.target.value })
          }
        />
        {this.state.inputMealValue.length > 2 ? (
          <ul>
            {filteredMealData.map((item) => (
              <li
                key={item.id}
                onClick={() => this.onMealSuggestionSelected(item)}
              >
                {item.meal}
              </li>
            ))}
          </ul>
        ) : null}
        <br></br> */}
        <Card sx={{ minWidth: 275 }}>
          <CardContent align="center">
            <Autocomplete
              id="meal-autocomplete"
              freeSolo
              sx={{ width: "25vh" }}
              options={filteredMealData.map((option) => option.meal)}
              onChange={handleChangeMeal}
              renderInput={(params) => (
                <TextField {...params} label="Choose the Meal" />
              )}
            />
            <CardContent align="center">
            <Autocomplete
              id="drink-autocomplete"
              freeSolo
              sx={{ width: "25vh" }}
              options={filteredDrinkData.map((option) => option.drink)}
              onChange={handleChangeDrink}
              renderInput={(params) => (
                <TextField {...params} label="Choose the Drink" />
              )}
            />
             <Button
              onClick={() => this.onSaveBreakfast()}
              variant="contained"
              color="primary"
              size="small"
            >
              Save Breakfast
            </Button>
          </CardContent>
          </CardContent>
        </Card>
        {/* Drink Search: <br></br>
        <input
          type="text"
          value={this.state.inputDrinkValue}
          onChange={(event) =>
            this.setState({ inputDrinkValue: event.target.value })
          }
        />
        {this.state.inputDrinkValue.length > 2 ? (
          <ul>
            {filteredDrinkData.map((item) => (
              <li
                key={item.id}
                onClick={() => this.onDrinkSuggestionSelected(item)}
              >
                {item.drink}
              </li>
            ))}
          </ul>
        ) : null} */}
        {/* <br></br>
        <button onClick={() => this.onSaveBreakfast()}> Save Breakfast </button> */}
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  mealList: state.breakfast.mealList,
  drinkList: state.breakfast.drinkList,
  hashCode: state.sesion.sesionHash,
});

const mapDispatchToProps = {
  createBreakfast,
  fetchMealList,
  fetchDrinkList,
  fetchBreakfastHash,
};

export default connect(mapStateToProps, mapDispatchToProps)(Breakfast);
