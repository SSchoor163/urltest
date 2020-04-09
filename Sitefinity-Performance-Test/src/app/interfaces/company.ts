import { GtMetrics } from './gt-metrics';

export interface Company {
    id:number;
    businessType:string;
    companyName:string;
    url:string;
    sfVersion:number;
    endEnterpriseSupport:Date;
    sitefinityRetirmentDate:Date;
    previousVersion:number;
    confirmedVersionDate:Date;
    contacted:boolean;
    notes:string;
    rankingScale:number;
    country:string;
    state_Region:string;
    city:string;
    street:string;
    zipCode:string;
    gtMetricsId:number;
    gtMetrics:GtMetrics;
}
