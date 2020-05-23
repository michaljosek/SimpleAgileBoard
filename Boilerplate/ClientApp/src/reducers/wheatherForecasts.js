import createReducer from '../store/createReducer.js'
import * as types from '../actions/type.js'

const unloadedState = { forecasts: [], isLoading: false };

export const weatherForecasts = createReducer(unloadedState, {
    [types.RECEIVE_WEATHER_FORECASTS](state, action) {
       // console.log(state);
        if (state === undefined) {
            return unloadedState;
        }
        var data = action.data;
        // Only accept the incoming data if it matches the most recent request. This ensures we correctly
        // handle out-of-order responses.
        if (data.startDateIndex === state.startDateIndex) {
            return {
                startDateIndex: data.startDateIndex,
                forecasts: data.forecasts,
                isLoading: false
            };
        } 
    },
    [types.REQUEST_WEATHER_FORECASTS](state, action) {
        if (state === undefined) {
            return unloadedState;
        }

        return {
            startDateIndex: action.data.startDateIndex,
            forecasts: state.forecasts,
            isLoading: true
        };
    }

});

