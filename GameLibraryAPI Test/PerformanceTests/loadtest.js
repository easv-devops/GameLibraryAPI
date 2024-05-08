import http from 'k6/http'
import {sleep, check} from 'k6';

export const options = {
    stages: [
        {duration: '5m', target: 60},
        {duration: '10m', target: 60},
        {duration: '5m', target: 0},
    ],
    thresholds: {
        http_req_duration: ['p(99)<100'],
    }
};

export default () => {
    const res = http.get('http://localhost:5216/')
}
