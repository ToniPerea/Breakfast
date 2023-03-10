import React from "react";
import { connect } from "react-redux";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import styles from "./List.module.css";

class List extends React.Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    const { breakfast, mealList, drinkList } = this.props;

    ///////////// MEALS PART ////////////////////

    const mealCounts = breakfast.reduce((acc, item) => {
      if (item.mealId in acc) {
        acc[item.mealId]++;
      } else {
        acc[item.mealId] = 1;
      }
      return acc;
    }, {});

    const mealCountsFixed = mealList
      .map((meal) => {
        const count = mealCounts[meal.id] || 0;
        return { meal: meal.meal, count };
      })
      .filter((mealCount) => mealCount.count > 0);

    ///////////// DRINKS PART ////////////////////

    const drinkCounts = breakfast.reduce((acc, item) => {
      if (item.drinkId in acc) {
        acc[item.drinkId]++;
      } else {
        acc[item.drinkId] = 1;
      }
      return acc;
    }, {});

    const drinkCountsFixed = drinkList
      .map((drink) => {
        const count = drinkCounts[drink.id] || 0;
        return { drink: drink.drink, count };
      })
      .filter((drinkCount) => drinkCount.count > 0);

    return (
      <div>
        {mealCountsFixed.length > 0 || drinkCountsFixed.length > 0 ? (
          <>
            {/* <h4>Meals for Order:</h4>
            <ul>
              {mealCountsFixed.map((mealCount) => (
                <li key={mealCount.meal}>
                  {mealCount.meal} x {mealCount.count}
                </li>
              ))}
            </ul>
            <h4>Drinks for Order:</h4>
            <ul>
              {drinkCountsFixed.map((drinkCount) => (
                <li key={drinkCount.drink}>
                  {drinkCount.drink} x {drinkCount.count}
                </li>
              ))}
            </ul> */}
            <TableContainer sx={{ marginBottom: "10px" }} component={Paper}>
              <Table
                sx={{ minWidth: 650, marginBottom: "10px" }}
                aria-label="simple table"
              >
                <TableHead>
                  <TableRow>
                    <TableCell>
                      <u>Meals</u>
                    </TableCell>
                    <TableCell align="right">
                      <u>Quantity</u>
                    </TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {mealCountsFixed.map((mealCount) => (
                    <TableRow
                      key={mealCount.meal}
                      sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {mealCount.meal}
                      </TableCell>
                      <TableCell align="right">{mealCount.count}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell>
                      <u>Drinks</u>
                    </TableCell>
                    <TableCell align="right">
                      <u>Quantity</u>
                    </TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {drinkCountsFixed.map((drinkCount) => (
                    <TableRow
                      key={drinkCount.drink}
                      sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {drinkCount.drink}
                      </TableCell>
                      <TableCell align="right">{drinkCount.count}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </>
        ) : (
          <Card sx={{ minWidth: 275 }}>
            <CardContent align="center">
              No Breakfast Selected
            </CardContent>
          </Card>
        )}
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  breakfast: state.sesion.breakfast,
  mealList: state.breakfast.mealList,
  drinkList: state.breakfast.drinkList,
});

export default connect(mapStateToProps)(List);
