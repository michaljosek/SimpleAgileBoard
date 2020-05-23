import * as types from './type.js'
export const requestWeatherForecastsAction = {
    requestWeatherForecasts: (startDateIndex) => {
        return (dispatch, getState) => {
            const appState = getState();
            if (appState && appState.weatherForecasts && startDateIndex !== appState.weatherForecasts.startDateIndex) {
                fetch(`weatherforecast`)
                    .then(response => response.json())
                    .then(data => {
                        dispatch(
                            setWeatherForecasts(types.RECEIVE_WEATHER_FORECASTS, { startDateIndex: startDateIndex, forecasts: data }));
                    });
                dispatch(
                    setWeatherForecasts(types.REQUEST_WEATHER_FORECASTS, { startDateIndex: startDateIndex }));
            }
        }
    }
};
const setWeatherForecasts = (type, data) => {
    return {
        type: type,
        data: data,
    }
}