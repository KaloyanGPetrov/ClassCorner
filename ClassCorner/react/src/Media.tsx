import { List, SimpleForm, ListProps, useListContext } from 'react-admin';
import { Box , Card, CardContent, CardMedia } from '@mui/material';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import SkipPreviousIcon from '@mui/icons-material/SkipPrevious';
import PlayArrowIcon from '@mui/icons-material/PlayArrow';
import SkipNextIcon from '@mui/icons-material/SkipNext';
import { CardActionArea, useTheme } from '@mui/material';


export const MediaControlCard = () => {
  const theme = useTheme();

  return (
    <Card sx={{ display: 'flex' }}>
      <Box sx={{ display: 'flex', flexDirection: 'column' }}>
        <CardContent sx={{ flex: '1 0 auto' }}>
          <Typography component="div" variant="h5">
            Static noises
          </Typography>
          <Typography variant="subtitle1" color="text.secondary" component="div">
            Bzzzzzzz
          </Typography>
        </CardContent>
        <Box sx={{ display: 'flex', alignItems: 'center', pl: 1, pb: 1 }}>
          <IconButton aria-label="previous">
            {theme.direction === 'rtl' ? <SkipNextIcon /> : <SkipPreviousIcon />}
          </IconButton>
          <IconButton aria-label="play/pause">
            <PlayArrowIcon sx={{ height: 38, width: 38 }} />
          </IconButton>
          <IconButton aria-label="next">
            {theme.direction === 'rtl' ? <SkipPreviousIcon /> : <SkipNextIcon />}
          </IconButton>
        </Box>
      </Box>
      <CardMedia
        component="img"
        sx={{ width: 151 }}
        image="needs an image"
        alt="use your imagination cuz i'm too lazy to add an image"
      />
    </Card>
  );
}

export const ActionAreaCard = () => {
    return (
      <Card sx={{ maxWidth: 345 }}>
        <CardActionArea>
          <CardMedia
            component="img"
            height="140"
            image="\public\jingliu.png"
            alt="silly sword lady"
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              Jingliu
            </Typography>
            <Typography variant="body2" color="text.secondary">
              Jingliu is a character from the game Honkai Star Rail, associated with the moon
              and part of the now disbanded ground "High-Cloud Quintet".
            </Typography>
          </CardContent>
        </CardActionArea>
      </Card>
    );
  }

const MediaListContent = () => {
    useListContext();
    return (
        <Box sx={{ display: 'grid', gridTemplateColumns: '1fr', gap: 5 }}>
        <MediaControlCard />
        <ActionAreaCard />
      </Box>
    );
  }
  
  export const MediaList = () => (
    <List>
      <SimpleForm>
        <MediaListContent />
      </SimpleForm>
    </List>
  );