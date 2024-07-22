import React, { ReactNode } from 'react';
import { Layout as RALayout, CheckForApplicationUpdate, LayoutProps } from 'react-admin';
import CustomAppBar from './CustomAppBar';
import { Box, SpeedDial, SpeedDialIcon, SpeedDialAction } from '@mui/material';
import AddPhotoAlternateIcon from '@mui/icons-material/AddPhotoAlternate';
import AddIcon from '@mui/icons-material/Add';
import ShareIcon from '@mui/icons-material/Share';

const actions = [
  { icon: <AddIcon />, name: 'Add' },
  { icon: <AddPhotoAlternateIcon />, name: 'Add Photo' },
  { icon: <ShareIcon />, name: 'Share' },
];

export const ControlledOpenSpeedDial = () => {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <SpeedDial
      ariaLabel="SpeedDial controlled open example"
      sx={{ position: 'fixed', bottom: 16, right: 16 }}
      icon={<SpeedDialIcon />}
      onClose={handleClose}
      onOpen={handleOpen}
      open={open}
    >
      {actions.map((action) => (
        <SpeedDialAction
          key={action.name}
          icon={action.icon}
          tooltipTitle={action.name}
          onClick={handleClose}
        />
      ))}
    </SpeedDial>
  );
};

export const Layout = ({ children }: { children: ReactNode }) => (
  <RALayout appBar={CustomAppBar}>
    <Box sx={{ display: 'flex', flexDirection: 'column', height: '100vh' }}>
      <Box sx={{ flex: 1 }}>
        {children}
      </Box>
      <ControlledOpenSpeedDial />
      <CheckForApplicationUpdate />
    </Box>
  </RALayout>
);
