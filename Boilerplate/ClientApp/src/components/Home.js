import * as React from 'react';
import { connect } from 'react-redux';

const Home = props => {
    return (
        <div>
            Projekt ZTP
        </div>
    );
};
export default connect()(React.memo(Home));
