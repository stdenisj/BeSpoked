import { Card, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { Customer } from "../../../Entities/Customer";

type CustomerCardProps = {
    customer:Customer
};

export function CustomerCard(props:CustomerCardProps){
    const { customer } = props

    return(
        <Grid item xs={12} sm={6} md={4} lg={3}>
            <Card >
                <CardMedia
                sx={{ height: 140 }}
                image="https://placekitten.com/200/287"
                />
                <CardContent>
                    <Typography gutterBottom variant="h5" component="div">
                        {`${customer.firstName} ${customer.lastName}`}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Phone: {customer.phone}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        StartDate: {customer.startDate.toLocaleDateString("en-US")}
                    </Typography>
                </CardContent>
            </Card>
        </Grid>
    )
}