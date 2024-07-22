import React from 'react';
import { AppBar, AppBarProps } from 'react-admin';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';

const CustomAppBar = (props: AppBarProps) => (
  <AppBar {...props}>
    <Box sx={{ display: 'flex', alignItems: 'center', width: '100%', padding: '0 16px', justifyContent: 'space-between' }}>
      <Box sx={{ display: 'flex', alignItems: 'center' }}>
        <img src="/class corner.png" alt="Logo" style={{ height: 40, marginRight: 8 }} />
        <Typography variant="h6" color="inherit">
          ClassCorner
        </Typography>
      </Box>
    </Box>
  </AppBar>
);

export default CustomAppBar;