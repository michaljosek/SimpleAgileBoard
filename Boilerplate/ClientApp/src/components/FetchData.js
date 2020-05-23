import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux'

import { Link } from 'react-router-dom';
import { requestWeatherForecastsAction } from '../actions/WheatherForecasts'
class FetchData extends React.PureComponent {
    // This method is called when the component is first added to the document
    componentDidMount() {
        this._ensureDataFetched();
    }

    // This method is called when the route parameters change
    componentDidUpdate() {
        this._ensureDataFetched();
    }

    render() {

        return (
            <React.Fragment>
                <h1 id="tabelLabel">Weather forecast</h1>
                <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
                {this._renderForecastsTable()}
                {this._renderPagination()}
            </React.Fragment>
        );
    }

    _ensureDataFetched() {
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    _renderForecastsTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.forecasts.map((forecast) =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    _renderPagination() {
        const prevStartDateIndex = (this.props.startDateIndex || 0) - 5;
        const nextStartDateIndex = (this.props.startDateIndex || 0) + 5;

        return (
            <div className="d-flex justify-content-between">
                <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-data/${prevStartDateIndex}`}>Previous</Link>
                {this.props.isLoading && <span>Loading...</span>}
                <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-data/${nextStartDateIndex}`}>Next</Link>
            </div>
        );
    }
}


function mapDispatchToProps(dispatch) {
    return bindActionCreators(requestWeatherForecastsAction, dispatch);
}

function mapStateToProps(state) {

    return Object.assign({}, state.weatherForecasts);
}
export default connect(mapStateToProps, mapDispatchToProps)(FetchData);