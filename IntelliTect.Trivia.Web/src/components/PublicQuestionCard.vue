<template>
  <v-card>
    <v-sheet color="secondary">
      <v-card-title> {{ question.text }} </v-card-title>
      <v-spacer />
      <v-chip
        v-if="isCorrect !== null"
        :color="isCorrect ? 'success' : 'error'"
        variant="flat"
      >
        {{ isCorrect ? "Yay, you got it correct" : "Wrong Answer" }}
      </v-chip>
    </v-sheet>

    <v-card-text>
      <v-chip
        @click="guessAnswer(answer)"
        v-for="answer in question.answers"
        :key="answer.answerId!"
        class="mx-1"
      >
        {{ answer.text }}
      </v-chip>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { PublicAnswerDto, PublicQuestionDto } from "@/models.g";
import { QuestionServiceViewModel } from "@/viewmodels.g";

const props = defineProps<{
  question: PublicQuestionDto;
  questionService: QuestionServiceViewModel;
}>();

const isCorrect = ref<null | boolean>(null);

async function guessAnswer(answer: PublicAnswerDto) {
  isCorrect.value = null;
  isCorrect.value = await props.questionService.guessAnswer(answer.answerId);
}
</script>
